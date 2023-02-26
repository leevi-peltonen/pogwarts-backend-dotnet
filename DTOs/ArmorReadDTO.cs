using web_api.Models;

namespace web_api.DTOs
{
    public class ArmorReadDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Defense { get; set; }
        public int Price { get; set; }
        public Rarity Rarity { get; set; }
    }
}
