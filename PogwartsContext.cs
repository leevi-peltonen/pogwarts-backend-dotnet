using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Attribute = web_api.Models.Attribute;
using System.Data;
using web_api.Data;

namespace web_api
{
    public class PogwartsContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<WeaponPerk> WeaponPerk { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Enemy> Enemy { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Boss> Boss { get; set; }

        public PogwartsContext(DbContextOptions<PogwartsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Weapon>().ToTable("Weapon").HasData(SeedHelper.SeedWeapons());
            modelBuilder.Entity<Armor>().ToTable("Armor");
            modelBuilder.Entity<Enemy>().ToTable("Enemy");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<WeaponPerk>().ToTable("WeaponPerk").HasData(SeedHelper.SeedPerks());
            modelBuilder.Entity<Boss>().ToTable("Boss").HasData(SeedHelper.SeedBosses());


            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.InventoryWeapons)
                .WithOne(w => w.CharactersInventory);

            modelBuilder.Entity<Character>()
                .HasOne(c => c.EquippedWeapon)
                .WithOne(w => w.CharactersEquipped);


            //many to many: many characters, many armor in inventory
            modelBuilder.Entity<Character>()
                .HasMany(c => c.InventoryArmor)
                .WithMany(a => a.CharactersInventory)
                .UsingEntity<Dictionary<string, object>>(
                "CharacterInventoryArmor",
                r => r.HasOne<Armor>().WithMany().HasForeignKey("ArmorId"),
                l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                je => je.HasKey("ArmorId", "CharacterId"));

            // one to many: character equipped armor
            modelBuilder.Entity<Armor>()
                .HasMany(a => a.CharactersEquipped)
                .WithOne(c => c.EquippedArmor)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}