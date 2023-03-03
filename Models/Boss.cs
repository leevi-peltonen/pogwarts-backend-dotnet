using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Boss
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BossId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Defense { get; set; }
        public bool IsAlive { get; set; }



        public static int calculateBossMinDamage()
        {
            var rng = new Random();
            return rng.Next(40, 50);
        }

        public static int calculateBossMaxDamage()
        {
            var rng = new Random();
            return rng.Next(60, 80);
        }



    }
}
