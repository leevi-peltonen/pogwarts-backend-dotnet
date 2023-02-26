using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    public class Weapon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public Rarity Rarity { get; set; }
        public ICollection<Character>? CharactersInventory { get; set; }
        
        public ICollection<Character>? CharactersEquipped { get; set; }
    }
}
