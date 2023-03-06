
using Microsoft.CodeAnalysis.CSharp.Syntax;
using web_api.Models;

namespace web_api.Data
{
    public static class SeedHelper
    {
        public static ICollection<WeaponPerk> SeedPerks()
        {
            var perks = new List<WeaponPerk>();

            foreach(WeaponPrefix i in Enum.GetValues(typeof(WeaponPrefix)))
            {
                var perk = new WeaponPerk(i);
                perks.Add(perk);
            }
            return perks;
        }

        public static ICollection<Weapon> SeedWeapons()
        {
            var weapons = new List<Weapon>();
            List<string> names = new List<string>(){"Sword", "Bow", "Staff"};

            foreach(string name in names)
            {
                var weapon = new Weapon() 
                {
                    WeaponId = names.FindIndex(w => w == name) + 1,
                    Name = name,
                    Type = (WeaponType)names.FindIndex(w => w == name),
                    Description = Weapon.GetDescription(name),
                    Damage = Weapon.CalculateDamage(2, Rarity.Common),
                    CritDamage = 0,
                    CritChance = 0,
                    StunChance = 0,
                    PoisonChance = 0,
                    LifestealChance = 0,
                    Price = 10,
                    Rarity = Rarity.Common
                    
                };
                weapons.Add(weapon);
            }
            return weapons;
        }

        public static ICollection<Boss> SeedBosses()
        {
            var bosses = new List<Boss>();
            List<string> names = new List<string>() { "Malakar the Dark Lord", "Drogath the Colossus Ogre", "Azura the Elemental Queen", "Ragnarok the World Ender" };

            foreach(string name in names)
            {
                var boss = new Boss()
                {
                    BossId = names.FindIndex(w => w == name) + 1,
                    Name = name,
                    MaxDamage = Boss.calculateBossMaxDamage(),
                    MinDamage = Boss.calculateBossMinDamage(),
                    Level = 50,
                    Defense = 50,
                    IsAlive = true,
                    Health = 1000,
                    MaxHealth = 1000

                };
                bosses.Add(boss);
            }
            return bosses;
        }

        public static ICollection<Achievement> SeedAchievements()
        {
            var achievements = new List<Achievement>
            {
                new Achievement()
                {
                    AchievementId = 1,
                    Name = "Beginner's Luck",
                    Description = "Level up for the first time",
                    Reward = 10,
                    IsHidden = false
                },
                new Achievement()
                {
                    AchievementId = 2,
                    Name = "Challenge Accepted",
                    Description = "Reach level 10",
                    Reward = 100,
                    IsHidden = false
                },
                new Achievement()
                {
                    AchievementId = 3,
                    Name = "High Scorer",
                    Description = "Reach level 50",
                    Reward = 500,
                    IsHidden = false
                }
            };

            return achievements;
        }


    }
}
