using web_api.Models;

namespace web_api.DTOs
{
    public class WeaponReadDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public Rarity Rarity { get; set; }
    }
}
