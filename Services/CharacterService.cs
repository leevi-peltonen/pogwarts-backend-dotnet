using Microsoft.EntityFrameworkCore;
using web_api.Models;
using web_api.DTOs;
using Microsoft.OpenApi.Validations;

namespace web_api.Services
{
    public class CharacterService
    {
        private readonly PogwartsContext _context;
        public CharacterService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Character>> GetAllCharactersAsync()
        {
            var characters = await _context.Character
                .Include(c => c.InventoryWeapons)
                .Include(c => c.InventoryArmor)
                .ToListAsync();

            return characters;
        }

        public async Task<Character> GetCharacterByIdAsync(int id)
        {
            Character character = await _context.Character.FindAsync(id);
            if(character != null)
            {
                return character;
            }else
            {
                return null;
            }
        }

        public async Task<Character> CreateCharacterAsync(Character character)
        {
            if(!CharacterExists(character.Name))
            {
                _context.Character.Add(character);
                await _context.SaveChangesAsync();
                return character;
            }
            throw new Exception("Character exists with that name!");
        }

        public async Task<Character> AddWeaponToInventoryAsync(string weaponName, string characterName)
        {
            var character = _context.Character
                .Include(c => c.InventoryWeapons)
                .FirstOrDefault(c => c.Name == characterName);
            var weapon = await _context.Weapon.FirstAsync(w => w.Name == weaponName);
            character.InventoryWeapons.Add(weapon);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> RemoveWeaponFromInventoryAsync(string weaponName, string characterName)
        {
            var character = _context.Character
                .Include(c => c.InventoryWeapons)
                .FirstOrDefault(c => c.Name == characterName);
            var weapon = await _context.Weapon.FirstAsync(w => w.Name == weaponName);
            character.InventoryWeapons.Remove(weapon);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> UpdateCoinsAsync(int coins, string characterName)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Name == characterName);
            character.Coins = coins;
            await _context.SaveChangesAsync();
            return character;
        }


        public async Task<Character> UpdateAttributesAsync(int strength, int dexterity, int intelligence, string characterName)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Name == characterName);
            character.Strength = strength;
            character.Dexterity = dexterity;
            character.Intelligence = intelligence;
            await _context.SaveChangesAsync();
            return character;

        }

        public async Task<Character> UpdateLevelAsync(int level, string characterName)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Name == characterName);
            character.Level = level;
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> UpdateExperienceAsync(int experience, string characterName)
        {
            var character = await _context.Character.FirstOrDefaultAsync(c => c.Name == characterName);
            character.Experience = experience;
            await _context.SaveChangesAsync();
            return character;
        }


        private bool CharacterExists(string characterName)
        {
            return _context.Character.Any(c => c.Name == characterName);
        }

    }
}
