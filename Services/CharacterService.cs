using Microsoft.EntityFrameworkCore;
using web_api.Models;
using web_api.DTOs;

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
            _context.Character.Add(character);
            await _context.SaveChangesAsync();
            return character;
        }

    }
}
