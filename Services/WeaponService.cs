using Microsoft.EntityFrameworkCore;
using web_api.Models;

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
    }
}
