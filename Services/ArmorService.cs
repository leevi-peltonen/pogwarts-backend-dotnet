using web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace web_api.Services
{
    public class ArmorService
    {
        private readonly PogwartsContext _context;
        public ArmorService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<Armor> GetArmorByNameAsync(string name)
        {
            var armor = await _context.Armor.FirstAsync(a => a.Name == name);
            if (armor == null)
            {
                return null;
            }

            return armor;
        }
        public async Task<ICollection<Armor>> GetAllArmorAsync()
        {
            var armor = await _context.Armor.ToListAsync();
            return armor;
        }
    }
}
