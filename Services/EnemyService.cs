using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Services
{
    public class EnemyService
    {
        private readonly PogwartsContext _context;
        public EnemyService(PogwartsContext context)
        {
            _context = context;
        }   

        public async Task<ICollection<Enemy>> GetAllEnemiesAsync()
        {
            var enemies = await _context.Enemy.ToListAsync();
            return enemies;
        }
    }
}
