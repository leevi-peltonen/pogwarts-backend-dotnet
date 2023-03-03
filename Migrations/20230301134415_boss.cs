using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace web_api.Migrations
{
    /// <inheritdoc />
    public partial class boss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boss",
                columns: table => new
                {
                    BossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    MinDamage = table.Column<int>(type: "int", nullable: false),
                    MaxDamage = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    IsAlive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boss", x => x.BossId);
                });

            migrationBuilder.InsertData(
                table: "Boss",
                columns: new[] { "BossId", "Defense", "Health", "IsAlive", "Level", "MaxDamage", "MaxHealth", "MinDamage", "Name" },
                values: new object[,]
                {
                    { 1, 50, 1000, true, 50, 74, 1000, 48, "Malakar the Dark Lord" },
                    { 2, 50, 1000, true, 50, 62, 1000, 47, "Drogath the Colossus Ogre" },
                    { 3, 50, 1000, true, 50, 65, 1000, 41, "Azura the Elemental Queen" },
                    { 4, 50, 1000, true, 50, 67, 1000, 46, "Ragnarok the World Ender" }
                });

            migrationBuilder.UpdateData(
                table: "Weapon",
                keyColumn: "WeaponId",
                keyValue: 1,
                column: "Damage",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Weapon",
                keyColumn: "WeaponId",
                keyValue: 3,
                column: "Damage",
                value: 23);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boss");

            migrationBuilder.UpdateData(
                table: "Weapon",
                keyColumn: "WeaponId",
                keyValue: 1,
                column: "Damage",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Weapon",
                keyColumn: "WeaponId",
                keyValue: 3,
                column: "Damage",
                value: 21);
        }
    }
}
