
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
        public int EquippedWeaponId { get; set; }
        public int EquippedArmorId { get; set; }
        public User User { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Armor> Armor { get; set; }
        public ICollection<Attribute> Attributes { get; set; }

    }
}
