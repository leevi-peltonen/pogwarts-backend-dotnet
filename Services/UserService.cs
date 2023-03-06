using MessagePack.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using web_api.Models;

namespace web_api.Services
{
    public class UserService
    {
        private readonly PogwartsContext _context;
        public UserService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var allUsers =  _context.User
                .Include(u => u.Characters)
                    .ThenInclude(c => c.InventoryWeapons)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.InventoryArmor)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.ActiveContract)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.EquippedWeapon)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.Achievements)
                .ToList();
            
            User user = allUsers.Find(user => user.UserId == id);
                        
            if(user != null)
            {
                return user;
            }else
            {
                return null;
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            var allUsers = _context.User
                .Include(u => u.Characters)
                    .ThenInclude(c => c.InventoryWeapons)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.InventoryArmor)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.ActiveContract)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.EquippedWeapon)
                .Include(u => u.Characters)
                    .ThenInclude(c => c.Achievements)
                .ToList();
            User user = allUsers.Find(user => user.Name == name);
            if(user!=null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if(!UserExists(user.Name))
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new Exception("User Exists!");
        }

        private bool UserExists(string userName)
        {
            return _context.User.Any(u => u.Name == userName);
        }

    }
}
