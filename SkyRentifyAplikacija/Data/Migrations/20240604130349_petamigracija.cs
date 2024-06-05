using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyRentifyAplikacija.Data.Migrations
{
    /// <inheritdoc />
    public partial class petamigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Oprema",
                columns: new[] { "Id", "cijena", "marka", "materijal" },
                values: new object[,]
                {
                    { 4, 10.0, "Atomic", "Drvo" },
                    { 5, 15.0, "Salomon", "Plastika" },
                    { 6, 20.0, "Fischer", "Drvo" },
                    { 7, 25.0, "Salomon", "Plastika" },
                    { 8, 30.0, "Atomic", "Drvo" },
                    { 9, 10.0, "Atomic", "Drvo" },
                    { 10, 15.0, "Salomon", "Plastika" },
                    { 11, 20.0, "Fischer", "Drvo" },
                    { 12, 25.0, "Salomon", "Plastika" },
                    { 13, 10.0, "Atomic", "Drvo" },
                    { 14, 15.0, "Salomon", "Plastika" },
                    { 15, 20.0, "Fischer", "Drvo" },
                    { 16, 25.0, "Salomon", "Plastika" },
                    { 17, 30.0, "Nordic", "Drvo" }
                });

            migrationBuilder.InsertData(
                table: "Kaciga",
                columns: new[] { "Id", "velicina" },
                values: new object[,]
                {
                    { 4, "M" },
                    { 5, "L" },
                    { 6, "S" },
                    { 7, "M" },
                    { 8, "L" }
                });

            migrationBuilder.InsertData(
                table: "Pancerice",
                columns: new[] { "Id", "velicina" },
                values: new object[,]
                {
                    { 9, 40.0 },
                    { 10, 41.0 },
                    { 11, 42.0 },
                    { 12, 39.0 }
                });

            migrationBuilder.InsertData(
                table: "Snowboard",
                columns: new[] { "Id", "duzina" },
                values: new object[,]
                {
                    { 13, 160.0 },
                    { 14, 170.0 },
                    { 15, 180.0 },
                    { 16, 190.0 },
                    { 17, 200.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kaciga",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kaciga",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kaciga",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kaciga",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kaciga",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pancerice",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pancerice",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pancerice",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pancerice",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Snowboard",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Snowboard",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Snowboard",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Snowboard",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Snowboard",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Oprema",
                keyColumn: "Id",
                keyValue: 17);

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
    }
}
