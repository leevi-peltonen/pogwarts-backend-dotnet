using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using web_api.Connections;
using web_api.Models;

namespace web_api.Hubs
{
    [EnableCors("AllowAllHeaders")]
    public class BossHub : Hub
    {
        private static bool isBossFightStarted = false;
        private readonly string _botUser;
        private IDictionary<string, CharacterConnection> _connections;
        private static Dictionary<string, List<string>> _rooms = new Dictionary<string, List<string>>();

        private static Dictionary<string, int> _numPlayersInRoom = new Dictionary<string, int>();
        private static Dictionary<string, int> _numPlayersReady = new Dictionary<string, int>();
        private static Dictionary<string, int> _turnNumber = new Dictionary<string, int>();
        private static Dictionary<string, int> _actionsRemaining = new Dictionary<string, int>();


        private readonly PogwartsContext _context;
        public BossHub(IDictionary<string, CharacterConnection> connections, PogwartsContext context)
        {
            _botUser = "Botwarts";
            _connections = connections;
            _context = context;
        }

        public async Task<Boss> JoinRoom(CharacterConnection characterConnection)
        {
            if (isBossFightStarted)
            {
                throw new HubException("Boss fight has already started. Cannot join now.");
            }

            var connectionId = Context.ConnectionId;
            if (!_connections.TryGetValue(connectionId, out CharacterConnection connection))
            {
                connection = characterConnection;
                _connections[connectionId] = connection;
            }
            else
            {
                connection.Character = characterConnection.Character;
            }

            if (!_rooms.TryGetValue(characterConnection.Room, out List<string> players))
            {
                players = new List<string>();
                _rooms[characterConnection.Room] = players;
            }
            players.Add(characterConnection.Character);
           

            if (!Context.Items.ContainsKey(characterConnection.Room))
            {
                Context.Items.Add(characterConnection.Room, new List<string>());
            } else
            {
                _numPlayersInRoom[characterConnection.Room]++;
            }

            if(!_numPlayersInRoom.ContainsKey(characterConnection.Room))
            {
                _numPlayersInRoom.Add(characterConnection.Room, 1);
            } else
            {
                _numPlayersInRoom[characterConnection.Room]++;
            }


            var room = (List<string>)Context.Items[characterConnection.Room];
            if (!room.Contains(connectionId))
            {
                room.Add(connectionId);
            }

            int initialTurnNumber = players.Count - 1;
            _turnNumber[characterConnection.Room] = initialTurnNumber;
            _actionsRemaining[characterConnection.Room] = players.Count;
            Clients.Caller.SendAsync("SetTurnNumber", initialTurnNumber);


            await Groups.AddToGroupAsync(connectionId, characterConnection.Room);

            await Clients.Group(characterConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{characterConnection.Character} has joined the room");
            await Clients.Group(characterConnection.Room).SendAsync("PlayersInLobby", _numPlayersInRoom[characterConnection.Room]);
            var _boss = await _context.Boss.FirstAsync(b => b.Name == characterConnection.Room);
            
            return _boss;
        }

        public void PlayerActionCompleted(string roomName)
        {
            // Decrement the number of actions remaining for the room
            _actionsRemaining[roomName]--;

            // If all actions have been completed, increment the turn number and reset the actions remaining
            if (_actionsRemaining[roomName] == 0)
            {
                var rng = new Random();
                var damage = rng.Next(50, 100);
                //TODO: find random characterName from current connected characters -> set to characterToAttack
                var index = rng.Next(0, _rooms[roomName].Count);
                Console.WriteLine(_rooms[roomName]);
                var characterToAttack = _rooms[roomName][index];
                Console.WriteLine(characterToAttack);
                Clients.Group(roomName).SendAsync("BossAttacked", damage, characterToAttack);
                _turnNumber[roomName]++;
                _actionsRemaining[roomName] = _rooms[roomName].Count;
                Clients.Group(roomName).SendAsync("StartNextTurn");
            }
        }



        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Get the room name and decrement the count of players in that room
            if (_connections.TryGetValue(Context.ConnectionId, out CharacterConnection characterConnection))
            {
                _connections.Remove(Context.ConnectionId);
                await Clients.Group(characterConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{characterConnection.Character} has left");
                _numPlayersInRoom[characterConnection.Room]--;
                _actionsRemaining[characterConnection.Room]--;
                await Clients.Group(characterConnection.Room).SendAsync("PlayersInLobby", _numPlayersInRoom[characterConnection.Room]);
            }
            
            await base.OnDisconnectedAsync(exception);
        }

        public override async Task OnConnectedAsync()
        {
            if (isBossFightStarted)
            {
                throw new HubException("Boss fight has already started. Cannot join now.");
            }

            await base.OnConnectedAsync();
        }

        public async Task AttackBoss(string characterName, string room, int damage, Boss boss)
        {
            // Get the current turn number for the room
            int currentTurnNumber;
            if (!_turnNumber.TryGetValue(room, out currentTurnNumber))
            {
                currentTurnNumber = 0;
                _turnNumber[room] = currentTurnNumber;
            }


            // Attack the boss
            await Clients.All.SendAsync("PlayerAttacked", characterName, damage);
            boss.Health -= damage;
            if (boss.Health <= 0)
            {
                boss.Health = boss.MaxHealth;
                _context.Boss.Update(boss);
                await Clients.All.SendAsync("BossKilled", boss);
                _numPlayersReady[room] = 0;
                isBossFightStarted = false;
                await Clients.Group(room).SendAsync("PlayersReady", _numPlayersReady[room]);
            }
            else
            {

                _context.Boss.Update(boss);
                await Clients.All.SendAsync("BossStatus", boss);
            }

            await _context.SaveChangesAsync();
            // Signal that the player has completed their action for the turn
            await Clients.Group(room).SendAsync("PlayerActionCompleted", characterName);
            
            if (_actionsRemaining[room] == 0)
            {
                await Clients.Group(room).SendAsync("StartNextTurn");
            }
            
        }



        public async Task SendMessage(string message)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out CharacterConnection characterConnection))
            {
                await Clients.Group(characterConnection.Room)
                    .SendAsync("ReceiveMessage", characterConnection.Character, message);
            }
        }
        /*
        public async Task PlayerReadyOld(string playerName)
        {
            _numReadyPlayers++;

            await Clients.All.SendAsync("PlayerReady", playerName);

            if (_numReadyPlayers == Context.Items.Count)
            {
                await Clients.All.SendAsync("AllPlayersReady");
            }
        }
        */

        public async Task PlayerReady(string playerName, string room)
        {
            if (!_numPlayersInRoom.ContainsKey(room))
            {
                throw new ArgumentException($"Room {room} does not exist.");
            }

            await Clients.Group(room).SendAsync("PlayerReady", playerName);

            if (!_numPlayersReady.ContainsKey(room))
            {
                _numPlayersReady.Add(room, 1);
            } else
            {
                _numPlayersReady[room]++;
            }

            await Clients.Group(room).SendAsync("PlayersReady", _numPlayersReady[room]);

            if (_numPlayersReady[room]  == _numPlayersInRoom[room])
            {
                await Clients.Group(room).SendAsync("AllPlayersReady");
            }

        }


        public async Task StartBossFight(string bossName)
        {


                isBossFightStarted = true;
                await Clients.All.SendAsync("BossFightStarted", _numPlayersReady[bossName]);
            
        }


        public async Task LeaveLobby(string characterName, string room)
        {
            _connections.Remove(Context.ConnectionId);
            PlayerDied(characterName, room);
            await Clients.All.SendAsync("CharacterDied", characterName);
            _numPlayersInRoom[room]--;
            await Clients.Group(room).SendAsync("PlayersInLobby", _numPlayersInRoom[room]);
            
        }

        private void PlayerDied(string characterName, string room)
        {
            if (_rooms[room].Contains(characterName))
            {
                _rooms[room].Remove(characterName);
            }
        }

        public async Task EndBossFight(Boss boss, string room)
        {

            _numPlayersReady[room] = 0;
            isBossFightStarted = false;

            boss.Health = boss.MaxHealth;
            _context.Boss.Update(boss);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("BossFightEnded");
        }

        



    }
}
