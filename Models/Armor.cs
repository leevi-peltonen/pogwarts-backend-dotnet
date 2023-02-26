using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Armor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArmorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Defense { get; set; }
        public int Price { get; set; }
        public Rarity Rarity { get; set; }

        public ICollection<Character>? CharactersInventory { get; set; }

        public ICollection<Character>? CharactersEquipped { get; set; }
    }
}
