﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using web_api;

#nullable disable

namespace web_api.Migrations
{
    [DbContext(typeof(PogwartsContext))]
    [Migration("20230226140711_createEnemyTable")]
    partial class createEnemyTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterInventoryArmor", b =>
                {
                    b.Property<int>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("ArmorId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterInventoryArmor");
                });

            modelBuilder.Entity("CharacterInventoryWeapons", b =>
                {
                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("WeaponId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterInventoryWeapons");
                });

            modelBuilder.Entity("web_api.Models.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArmorId"));

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("ArmorId");

                    b.ToTable("Armor", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("AvailableAttributePoints")
                        .HasColumnType("int");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("Dexterity")
                        .HasColumnType("int");

                    b.Property<int?>("EquippedArmorArmorId")
                        .HasColumnType("int");

                    b.Property<int?>("EquippedWeaponWeaponId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("HighestLevelOfKilledMonsters")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("EquippedArmorArmorId");

                    b.HasIndex("EquippedWeaponWeaponId");

                    b.HasIndex("UserId");

                    b.ToTable("Character", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Enemy", b =>
                {
                    b.Property<int>("EnemyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnemyId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<bool>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EnemyId");

                    b.ToTable("Enemy", (string)null);
                });

            modelBuilder.Entity("web_api.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WeaponId"));

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Rarity")
                        .HasColumnType("int");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapon", (string)null);
                });

            modelBuilder.Entity("CharacterInventoryArmor", b =>
                {
                    b.HasOne("web_api.Models.Armor", null)
                        .WithMany()
                        .HasForeignKey("ArmorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CharacterInventoryWeapons", b =>
                {
                    b.HasOne("web_api.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("web_api.Models.Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("web_api.Models.Character", b =>
                {
                    b.HasOne("web_api.Models.Armor", "EquippedArmor")
                        .WithMany("CharactersEquipped")
                        .HasForeignKey("EquippedArmorArmorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("web_api.Models.Weapon", "EquippedWeapon")
                        .WithMany("CharactersEquipped")
                        .HasForeignKey("EquippedWeaponWeaponId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("web_api.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquippedArmor");

                    b.Navigation("EquippedWeapon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("web_api.Models.Armor", b =>
                {
                    b.Navigation("CharactersEquipped");
                });

            modelBuilder.Entity("web_api.Models.User", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("web_api.Models.Weapon", b =>
                {
                    b.Navigation("CharactersEquipped");
                });
#pragma warning restore 612, 618
        }
    }
}
