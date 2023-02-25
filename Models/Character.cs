
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
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int AvailableAttributePoints { get; set; }
        public int Coins { get; set; }
        public int HighestLevelOfKilledMonsters { get; set; }
        public User User { get; set; }


        public virtual ICollection<Weapon>? InventoryWeapons { get; set; }
        public virtual ICollection<Armor> InventoryArmor { get; set; }
        public ICollection<Attribute> Attributes { get; set; }


        public virtual Weapon EquippedWeapon { get; set; }

        public virtual Armor EquippedArmor { get; set; }
    }
}
