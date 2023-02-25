using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Weapon
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public string Rarity { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
