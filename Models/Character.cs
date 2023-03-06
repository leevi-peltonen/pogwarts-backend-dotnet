
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Character
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int Health { get; set; } = 100;
        public int MaxHealth { get; set; } = 100;
        public int AvailableAttributePoints { get; set; } = 0;
        public int Coins { get; set; } = 0;
        public int HighestLevelOfKilledMonsters { get; set; } = 0;
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public User User { get; set; }
        public Contract? ActiveContract { get; set; }
        public virtual ICollection<Weapon>? InventoryWeapons { get; set; }
        public virtual ICollection<Armor>? InventoryArmor { get; set; }

        public int? EquippedWeaponId { get; set; }

        public virtual Weapon? EquippedWeapon { get; set; }

        public virtual Armor? EquippedArmor { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
    }
}
