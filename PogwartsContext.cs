﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_api.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Attribute = web_api.Models.Attribute;
using System.Data;

namespace web_api
{
    public class PogwartsContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Weapon> Weapon { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Enemy> Enemy { get; set; }


        public PogwartsContext(DbContextOptions<PogwartsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Weapon>().ToTable("Weapon");
            modelBuilder.Entity<Armor>().ToTable("Armor");
            modelBuilder.Entity<Enemy>().ToTable("Enemy");
            // one to many: 1 user, many characters
            modelBuilder.Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User);
            //many to many: Many characters, many weapons in inventory
            modelBuilder.Entity<Character>()
                .HasMany(c => c.InventoryWeapons)
                .WithMany(w => w.CharactersInventory)
                .UsingEntity<Dictionary<string, object>>(
                "CharacterInventoryWeapons",
                r => r.HasOne<Weapon>().WithMany().HasForeignKey("WeaponId"),
                l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                je => je.HasKey("WeaponId", "CharacterId"));

            //many to many: many characters, many armor in inventory
            modelBuilder.Entity<Character>()
                .HasMany(c => c.InventoryArmor)
                .WithMany(a => a.CharactersInventory)
                .UsingEntity<Dictionary<string, object>>(
                "CharacterInventoryArmor",
                r => r.HasOne<Armor>().WithMany().HasForeignKey("ArmorId"),
                l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                je => je.HasKey("ArmorId", "CharacterId"));


            // one to many: character equipped weapon
            modelBuilder.Entity<Weapon>()
                .HasMany(w => w.CharactersEquipped)
                .WithOne(c => c.EquippedWeapon)
                .OnDelete(DeleteBehavior.SetNull);
            // one to many: character equipped armor
            modelBuilder.Entity<Armor>()
                .HasMany(a => a.CharactersEquipped)
                .WithOne(c => c.EquippedArmor)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}