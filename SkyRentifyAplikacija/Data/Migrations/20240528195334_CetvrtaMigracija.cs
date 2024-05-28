using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyRentifyAplikacija.Data.Migrations
{
    /// <inheritdoc />
    public partial class CetvrtaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Oprema",
                columns: new[] { "Id", "cijena", "marka", "materijal" },
                values: new object[,]
                {
                    { 1, 20.0, "Atomic", "Drvo" },
                    { 2, 30.0, "Salomon", "Plastika" }
                });

            migrationBuilder.InsertData(
                table: "Skije",
                columns: new[] { "Id", "duzina", "sirina" },
                values: new object[,]
                {
                    { 1, 160.0, 10.0 },
                    { 2, 170.0, 15.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skije",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skije",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
