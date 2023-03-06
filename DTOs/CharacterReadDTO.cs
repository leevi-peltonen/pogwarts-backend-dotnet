namespace web_api.DTOs
{
    public class CharacterReadDTO
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int AvailableAttributePoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Coins { get; set; }
        public int HighestLevelOfKilledMonsters { get; set; }
        public ICollection<WeaponReadDTO> InventoryWeapons { get; set; }
        public ICollection<ArmorReadDTO> InventoryArmor { get; set; }
        public WeaponReadDTO EquippedWeapon { get; set; }
        public ArmorReadDTO EquippedArmor { get; set; }
        public ContractReadDTO ActiveContract { get; set; }
        public ICollection<int> Achievements { get; set; }
    }
}
