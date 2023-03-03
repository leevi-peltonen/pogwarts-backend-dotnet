using Microsoft.EntityFrameworkCore;
using web_api.Models;
using web_api.Profiles;

namespace web_api.Services
{
    public class WeaponService
    {
        private readonly PogwartsContext _context;
        public WeaponService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<Weapon> GetWeaponByNameAsync(string name)
        {
            var weapon = await _context.Weapon.FirstAsync(w => w.Name == name);
            if (weapon == null)
            {
                return null;
            }

            return weapon;
        }

        public async Task<ICollection<Weapon>> GetAllWeaponsAsync()
        {
            var weapons = await _context.Weapon.ToListAsync();
            return weapons;
        }   

        public async Task<Weapon> CreateWeapon(int difficulty)
        {
            var rng = new Random();
            var rollForPerk = rng.Next(1, 100);
            var randomIndex = rng.Next(2, 11);
            var perk = rollForPerk < 80 ? await _context.WeaponPerk.FirstAsync(p => p.PerkId == 1) : await _context.WeaponPerk.FirstAsync(p => p.PerkId == randomIndex);
            var types = (WeaponType[])Enum.GetValues(typeof(WeaponType));
            var rngTypesIndex = rng.Next(0, types.Length);
            var type = types[rngTypesIndex];
            var weapon = new Weapon(type, perk, difficulty);
            return weapon;
        }

    }
}
