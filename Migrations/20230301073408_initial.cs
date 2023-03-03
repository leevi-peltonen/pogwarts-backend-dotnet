using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Armor",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Armor", x => x.ArmorId);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumEnemies = table.Column<int>(type: "int", nullable: false),
                    RewardCoins = table.Column<int>(type: "int", nullable: false),
                    ActiveCharacter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "Enemy",
                columns: table => new
                {
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    Attack = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy", x => x.EnemyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeaponPerk",
                columns: table => new
                {
                    PerkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    PrefixName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinDamage = table.Column<int>(type: "int", nullable: false),
                    MaxDamage = table.Column<int>(type: "int", nullable: false),
                    CritDamage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CritChance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Damage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StunChance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PoisonChance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LifestealChance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponPerk", x => x.PerkId);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    AvailableAttributePoints = table.Column<int>(type: "int", nullable: false),
                    Coins = table.Column<int>(type: "int", nullable: false),
                    HighestLevelOfKilledMonsters = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActiveContractContractId = table.Column<int>(type: "int", nullable: true),
                    EquippedWeaponId = table.Column<int>(type: "int", nullable: true),
                    EquippedArmorArmorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Character_Armor_EquippedArmorArmorId",
                        column: x => x.EquippedArmorArmorId,
                        principalTable: "Armor",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Character_Contract_ActiveContractContractId",
                        column: x => x.ActiveContractContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId");
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterInventoryArmor",
                columns: table => new
                {
                    ArmorId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterInventoryArmor", x => new { x.ArmorId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterInventoryArmor_Armor_ArmorId",
                        column: x => x.ArmorId,
                        principalTable: "Armor",
                        principalColumn: "ArmorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterInventoryArmor_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapon",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    CritDamage = table.Column<float>(type: "real", nullable: false),
                    CritChance = table.Column<float>(type: "real", nullable: false),
                    StunChance = table.Column<float>(type: "real", nullable: false),
                    PoisonChance = table.Column<float>(type: "real", nullable: false),
                    LifestealChance = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    CharactersInventoryCharacterId = table.Column<int>(type: "int", nullable: true),
                    WeaponPerkPerkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapon", x => x.WeaponId);
                    table.ForeignKey(
                        name: "FK_Weapon_Character_CharactersInventoryCharacterId",
                        column: x => x.CharactersInventoryCharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId");
                    table.ForeignKey(
                        name: "FK_Weapon_WeaponPerk_WeaponPerkPerkId",
                        column: x => x.WeaponPerkPerkId,
                        principalTable: "WeaponPerk",
                        principalColumn: "PerkId");
                });

            migrationBuilder.InsertData(
                table: "Weapon",
                columns: new[] { "WeaponId", "CharactersInventoryCharacterId", "CritChance", "CritDamage", "Damage", "Description", "LifestealChance", "Name", "PoisonChance", "Price", "Rarity", "StunChance", "Type", "WeaponPerkPerkId" },
                values: new object[,]
                {
                    { 1, null, 0f, 0f, 27, "A sword is a long, bladed weapon that is typically used for slashing or thrusting. It is commonly used in hand-to-hand combat, and can be wielded with one or two hands. Swords come in many shapes and sizes, and have been used throughout history by warriors and knights.", 0f, "Sword", 0f, 10, 0, 0f, 0, null },
                    { 2, null, 0f, 0f, 23, "A bow is a weapon that is used for firing arrows. It consists of a long, curved piece of material (such as wood or composite materials) that is strung with a taut string. Bows can be used for both hunting and warfare, and require a great deal of skill and strength to use effectively.", 0f, "Bow", 0f, 10, 0, 0f, 1, null },
                    { 3, null, 0f, 0f, 21, "A staff is a long, cylindrical weapon that is typically made from wood or metal. It can be used for both striking and blocking attacks, and is often used by martial artists or wizards.", 0f, "Staff", 0f, 10, 0, 0f, 2, null }
                });

            migrationBuilder.InsertData(
                table: "WeaponPerk",
                columns: new[] { "PerkId", "CritChance", "CritDamage", "Damage", "LifestealChance", "MaxDamage", "MinDamage", "Name", "PoisonChance", "PrefixName", "StunChance" },
                values: new object[,]
                {
                    { 1, 0m, 0m, 0m, 0m, 0, 0, 0, 0m, "None", 0m },
                    { 2, 0m, 0m, 3m, 0m, -5, 0, 1, 0m, "Blunt", 0m },
                    { 3, 0m, 0m, 0m, 0m, 2, 0, 2, 0m, "Sharp", 0m },
                    { 4, 0m, 0.2m, 0m, 0m, 0, 0, 3, 0m, "Piercing", 0m },
                    { 5, 0.1m, 0m, 0m, 0m, 0, 0, 4, 0m, "Precision", 0m },
                    { 6, 0m, 0m, 4m, 0m, 0, -3, 5, 0m, "Heavy", 0m },
                    { 7, 0m, 0m, 0m, 0.1m, 0, 0, 6, 0m, "Leeching", 0m },
                    { 8, 0.1m, 0.2m, 0m, 0m, 0, 0, 7, 0m, "Critical", 0m },
                    { 9, 0m, 0m, 0m, 0m, 0, 0, 8, 0m, "Stunning", 0.1m },
                    { 10, 0m, 0m, 0m, 0m, 0, 0, 9, 0.1m, "Poison", 0m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_ActiveContractContractId",
                table: "Character",
                column: "ActiveContractContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_EquippedArmorArmorId",
                table: "Character",
                column: "EquippedArmorArmorId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_EquippedWeaponId",
                table: "Character",
                column: "EquippedWeaponId",
                unique: true,
                filter: "[EquippedWeaponId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterInventoryArmor_CharacterId",
                table: "CharacterInventoryArmor",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharactersInventoryCharacterId",
                table: "Weapon",
                column: "CharactersInventoryCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_WeaponPerkPerkId",
                table: "Weapon",
                column: "WeaponPerkPerkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Weapon_EquippedWeaponId",
                table: "Character",
                column: "EquippedWeaponId",
                principalTable: "Weapon",
                principalColumn: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Armor_EquippedArmorArmorId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Contract_ActiveContractContractId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_User_UserId",
                table: "Character");

            migrationBuilder.DropForeignKey(
                name: "FK_Character_Weapon_EquippedWeaponId",
                table: "Character");

            migrationBuilder.DropTable(
                name: "CharacterInventoryArmor");

            migrationBuilder.DropTable(
                name: "Enemy");

            migrationBuilder.DropTable(
                name: "Armor");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Weapon");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "WeaponPerk");
        }
    }
}
