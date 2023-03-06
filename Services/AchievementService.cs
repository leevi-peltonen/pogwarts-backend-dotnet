using Microsoft.EntityFrameworkCore;
using web_api.Models;

namespace web_api.Services
{
    public class AchievementService
    {
        private readonly PogwartsContext _context;
        public AchievementService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Achievement>> GetAchievementsAsync()
        {
            var achievements = await _context.Achievement.ToListAsync();
            return achievements;
        }

        public async Task<Character> AddAchievementToCharacterAsync(int achievementId, string characterName)
        {
            var character = await _context.Character
                .Include(c => c.InventoryWeapons)
                .Include(c => c.EquippedWeapon)
                .Include(c => c.EquippedArmor)
                .Include(c => c.InventoryArmor)
                .Include(c => c.Achievements)
                .FirstAsync(c => c.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character with name {characterName} not found.");
            }

            var achievement = await _context.Achievement.FirstOrDefaultAsync(a => a.AchievementId == achievementId);
            if (achievement == null)
            {
                throw new ArgumentException($"Achievement with id {achievementId} not found.");
            }

            if(character.Achievements == null)
            {
                character.Achievements = new List<Achievement>();
            }

            character.Achievements.Add(achievement);
            await _context.SaveChangesAsync();

            return character;
        }

    }
}
