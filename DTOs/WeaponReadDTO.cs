using web_api.Models;

namespace web_api.DTOs
{
    public class WeaponReadDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public float CritDamage { get; set; } 
        public float CritChance { get; set; }
        public float StunChance { get; set; }
        public float PoisonChance { get; set; }
        public float LifestealChance { get; set; }
        public int Price { get; set; }
        public string Rarity { get; set; }
        public WeaponPerk WeaponPerk { get; set; }
    }
}
