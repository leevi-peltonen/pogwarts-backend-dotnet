namespace web_api.DTOs
{
    public class CharacterReadDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int AvailableAttributePoints { get; set; }
        public int Coins { get; set; }
        public int HighestLevelOfKilledMonsters { get; set; }
        public ICollection<WeaponReadDTO> InventoryWeapons { get; set; }
        public ICollection<ArmorReadDTO> InventoryArmor { get; set; }
        public ICollection<AttributeReadDTO> Attributes { get; set; }
        public WeaponReadDTO EquippedWeapon { get; set; }
        public ArmorReadDTO EquippedArmor { get; set; }
    }
}
