using System.ComponentModel.DataAnnotations;
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

    public enum WeaponType
    {
        Melee,
        Ranged,
        Magic
    }

    public enum MeleeWeaponName
    {
        Axe,
        Mace,
        Dagger,
        Whip,
        Spear
    }

    public enum RangedWeaponName
    {
        Bow,
        Crossbow,
        Javelin
    }

    public enum MagicWeaponName
    {
        Staff,
        Wand,
        Trident
    }
    public enum WeaponPrefix
    {
        None,
        Blunt,
        Sharp,
        Piercing,
        Precision,
        Heavy,
        Leeching,
        Critical,
        Stunning,
        Poison,
    }




    public class Weapon
    {
        private static readonly MeleeWeaponName[] meleeNames = (MeleeWeaponName[])Enum.GetValues(typeof(MeleeWeaponName));
        private static readonly RangedWeaponName[] rangedNames = (RangedWeaponName[])Enum.GetValues(typeof(RangedWeaponName));
        private static readonly MagicWeaponName[] magicNames = (MagicWeaponName[])Enum.GetValues(typeof(MagicWeaponName));



        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeaponId { get; set; }
        public WeaponType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public float CritDamage { get; set; }
        public float CritChance { get; set; }
        public float StunChance { get; set; }
        public float PoisonChance { get; set; }
        public float LifestealChance { get; set; }
        public int Price { get; set; }
        public Rarity Rarity { get; set; }
        public Character CharactersInventory { get; set; }
        public Character CharactersEquipped { get; set; }
        public WeaponPerk? WeaponPerk { get; set; }

        public Weapon(WeaponType type, WeaponPerk perk, int difficulty)
        {
            Rarity = CalculateRarity(difficulty);
            Type = type;
            WeaponPerk = perk;
            Damage = CalculateDamage(difficulty, Rarity);
            Price = CalculatePrice(difficulty, Rarity);
            
            switch (type) 
            {
                case WeaponType.Melee:
                    var meleeName = meleeNames[GetRandomIndex(meleeNames)];
                    Description = GetDescription(meleeName.ToString());
                    Name = (perk.PrefixName == "None") ? (meleeName.ToString()) : (perk.PrefixName + " " + meleeName);
                    break;
                case WeaponType.Ranged:
                    var rangedName = rangedNames[GetRandomIndex(rangedNames)];
                    Description = GetDescription(rangedName.ToString());
                    Name = (perk.PrefixName == "None") ? (rangedName.ToString()) : (perk.PrefixName  + " " + rangedName);
                    break;
                case WeaponType.Magic:
                    var magicName = magicNames[GetRandomIndex(magicNames)];
                    Description = GetDescription(magicName.ToString());
                    Name = (perk.PrefixName == "None") ? (magicName.ToString()) : (perk.PrefixName + " " + magicName);
                    break;
            }
        }

        public Weapon()
        {

        }

        private int GetRandomIndex<T>(T[] array)
        {
            var rng = new Random();
            return rng.Next(array.Length);
        }

        public static int CalculateDamage(int difficulty, Rarity rarity)
        {
            var rng = new Random();
            int baseDamage = rng.Next(8, 12);
            
            return baseDamage * difficulty + (1+(int)rarity) * 5;
        }

        private Rarity CalculateRarity(int difficulty)
        {
            var rng = new Random();
            var rarityRoll = rng.NextDouble();

            if (rarityRoll < 0.5 / difficulty)
            {
                return Rarity.Common;
            }
            else if (rarityRoll < 1.0 / difficulty)
            {
                return Rarity.Uncommon;
            }
            else if (rarityRoll < 2.0 / difficulty)
            {
                return Rarity.Rare;
            }
            else if (rarityRoll < 4.0 / difficulty)
            {
                return Rarity.Epic;
            }
            else
            {
                return Rarity.Legendary;
            }
        }

        private int CalculatePrice(int difficulty, Rarity rarity)
        {
            var rng = new Random();
            int basePrice = rng.Next(5,15) + 10*(int)rarity;
            
            return basePrice + difficulty * (int)rarity;
        }

        public static string GetDescription(string weaponType)
        {
            switch(weaponType)
            {
                case "Sword":
                    return "A sword is a long, bladed weapon that is typically used for slashing or thrusting. It is commonly used in hand-to-hand combat, and can be wielded with one or two hands. Swords come in many shapes and sizes, and have been used throughout history by warriors and knights.";
                case "Axe":
                    return "An axe is a weapon that has a long handle and a sharp, bladed head. It is typically used for chopping wood, but can also be used as a weapon. Axes can come in many different shapes and sizes, and can be used for both slashing and piercing attacks.";
                case "Mace":
                    return "A mace is a weapon that has a long handle and a heavy, spiked head. It is typically used for crushing or bashing attacks, and is often used by knights or other heavily-armored warriors. Maces can come in many different shapes and sizes, and can be made from a variety of materials.";
                case "Dagger":
                    return "A dagger is a short, bladed weapon that is typically used for stabbing or slashing. It is often used as a secondary weapon, and is popular among assassins and thieves due to its small size and concealability.";
                case "Whip":
                    return "A whip is a long, flexible weapon that is typically used for striking or entangling an opponent. It can be made from a variety of materials, such as leather or metal, and can be used for both long-range and close-range attacks.";
                case "Spear":
                    return "A spear is a long, pointed weapon that is typically used for thrusting. It can be wielded with one or two hands, and can be used for both close-range and long-range attacks. Spears have been used throughout history by many different cultures, and can come in many different shapes and sizes.";
                case "Bow":
                    return "A bow is a weapon that is used for firing arrows. It consists of a long, curved piece of material (such as wood or composite materials) that is strung with a taut string. Bows can be used for both hunting and warfare, and require a great deal of skill and strength to use effectively.";
                case "Crossbow":
                    return "A crossbow is a weapon that is similar to a bow, but is mounted on a stock and fired using a trigger. It is typically more powerful than a bow, and can be used for long-range attacks with greater accuracy and force.";
                case "Javelin":
                    return "A javelin is a long, spear-like weapon that is typically thrown at an opponent. It can be made from a variety of materials, and is often used in sports such as track and field.";
                case "Staff":
                    return "A staff is a long, cylindrical weapon that is typically made from wood or metal. It can be used for both striking and blocking attacks, and is often used by martial artists or wizards.";
                case "Wand":
                    return "A wand is a small, thin weapon that is typically made from wood or other materials. It is often used by wizards or other magic users to cast spells or perform other magical actions.";
                case "Trident":
                    return "A trident is a three-pronged spear-like weapon that is typically used for fishing or hunting. It can also be used as a weapon, and is often associated with the god Poseidon in Greek mythology.";
                default:
                    return "Item description not found";
            }
        }
    }
}