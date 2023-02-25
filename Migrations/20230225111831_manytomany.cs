using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon");

            migrationBuilder.DropIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Weapon");

            migrationBuilder.CreateTable(
                name: "CharacterWeapon",
                columns: table => new
                {
                    CharactersCharacterId = table.Column<int>(type: "int", nullable: false),
                    WeaponsWeaponId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterWeapon", x => new { x.CharactersCharacterId, x.WeaponsWeaponId });
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Character_CharactersCharacterId",
                        column: x => x.CharactersCharacterId,
                        principalTable: "Character",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterWeapon_Weapon_WeaponsWeaponId",
                        column: x => x.WeaponsWeaponId,
                        principalTable: "Weapon",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterWeapon_WeaponsWeaponId",
                table: "CharacterWeapon",
                column: "WeaponsWeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterWeapon");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Weapon",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapon_CharacterId",
                table: "Weapon",
                column: "CharacterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapon_Character_CharacterId",
                table: "Weapon",
                column: "CharacterId",
                principalTable: "Character",
                principalColumn: "CharacterId");
        }
    }
}
