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
    [Migration("20230225105342_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("web_api.Linkitystaulut.CharacterArmor", b =>
                {
                    b.Property<int>("CharacterArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterArmorId"));

                    b.Property<int>("ArmorId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("CharacterArmorId");

                    b.ToTable("CharacterArmor", (string)null);
                });

            modelBuilder.Entity("web_api.Linkitystaulut.CharacterAttribute", b =>
                {
                    b.Property<int>("CharacterAttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterAttributeId"));

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("CharacterAttributeId");

                    b.ToTable("CharacterAttribute", (string)null);
                });

            modelBuilder.Entity("web_api.Linkitystaulut.CharacterWeapon", b =>
                {
                    b.Property<int>("CharacterWeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterWeaponId"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("WeaponId")
                        .HasColumnType("int");

                    b.HasKey("CharacterWeaponId");

                    b.ToTable("CharacterWeapon", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Armor", b =>
                {
                    b.Property<int>("ArmorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArmorId"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

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

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArmorId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Armor", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Attribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttributeId"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributeId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Attribute", (string)null);
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

                    b.Property<int>("EquippedArmorId")
                        .HasColumnType("int");

                    b.Property<int>("EquippedWeaponId")
                        .HasColumnType("int");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("HighestLevelOfKilledMonsters")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("Character", (string)null);
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

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

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

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WeaponId");

                    b.HasIndex("CharacterId");

                    b.ToTable("Weapon", (string)null);
                });

            modelBuilder.Entity("web_api.Models.Armor", b =>
                {
                    b.HasOne("web_api.Models.Character", null)
                        .WithMany("Armor")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("web_api.Models.Attribute", b =>
                {
                    b.HasOne("web_api.Models.Character", null)
                        .WithMany("Attributes")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("web_api.Models.Character", b =>
                {
                    b.HasOne("web_api.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("web_api.Models.Weapon", b =>
                {
                    b.HasOne("web_api.Models.Character", null)
                        .WithMany("Weapons")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("web_api.Models.Character", b =>
                {
                    b.Navigation("Armor");

                    b.Navigation("Attributes");

                    b.Navigation("Weapons");
                });

            modelBuilder.Entity("web_api.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}