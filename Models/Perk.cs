using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api.Models
{
    public class WeaponPerk
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PerkId { get; set; }
        public WeaponPrefix Name { get; set; }
        public string PrefixName { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public decimal CritDamage { get; set; }
        public decimal CritChance { get; set; }
        public decimal Damage { get; set; }
        public decimal StunChance { get; set; }
        public decimal PoisonChance { get; set; }
        public decimal LifestealChance { get; set; }

        public WeaponPerk()
        {

        }


        public WeaponPerk(WeaponPrefix name)
        {
            Name = name;
            PrefixName = name.ToString();
            PerkId = (int)name + 1;
            switch (name)
            {
                case WeaponPrefix.None:
                    break;
                case WeaponPrefix.Blunt:
                    MaxDamage = -5;
                    Damage = 3;
                    break;
                case WeaponPrefix.Sharp:
                    MaxDamage = +2;
                    break;
                case WeaponPrefix.Piercing:
                    CritDamage = 0.2M;
                    break;
                case WeaponPrefix.Precision:
                    CritChance = 0.1M;
                    break;
                case WeaponPrefix.Heavy:
                    Damage = 4;
                    MinDamage = -3;
                    break;
                case WeaponPrefix.Leeching:
                    LifestealChance = 0.1M;
                    break;
                case WeaponPrefix.Critical:
                    CritChance = 0.1M;
                    CritDamage = 0.2M;
                    break;
                case WeaponPrefix.Stunning:
                    StunChance = 0.1M;
                    break;
                case WeaponPrefix.Poison:
                    PoisonChance = 0.1M;
                    break;
            }
        }
    }
}
