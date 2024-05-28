using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyRentifyAplikacija.Data.Migrations
{
    /// <inheritdoc />
    public partial class TrecaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "datumIzdavanjaUsluje",
                table: "Zahtjev",
                newName: "datumIzdavanjaUsluge");

            migrationBuilder.AlterColumn<string>(
                name: "prezime",
                table: "Klijent",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ime",
                table: "Klijent",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "datumIzdavanjaUsluge",
                table: "Zahtjev",
                newName: "datumIzdavanjaUsluje");

            migrationBuilder.AlterColumn<string>(
                name: "prezime",
                table: "Klijent",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "ime",
                table: "Klijent",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
