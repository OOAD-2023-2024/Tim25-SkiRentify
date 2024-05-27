using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyRentifyAplikacija.Data.Migrations
{
    /// <inheritdoc />
    public partial class DrugaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Klijent_klijentId",
                table: "Zahtjev");

            migrationBuilder.RenameColumn(
                name: "klijentId",
                table: "Zahtjev",
                newName: "KlijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Zahtjev_klijentId",
                table: "Zahtjev",
                newName: "IX_Zahtjev_KlijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Klijent_KlijentId",
                table: "Zahtjev",
                column: "KlijentId",
                principalTable: "Klijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zahtjev_Klijent_KlijentId",
                table: "Zahtjev");

            migrationBuilder.RenameColumn(
                name: "KlijentId",
                table: "Zahtjev",
                newName: "klijentId");

            migrationBuilder.RenameIndex(
                name: "IX_Zahtjev_KlijentId",
                table: "Zahtjev",
                newName: "IX_Zahtjev_klijentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zahtjev_Klijent_klijentId",
                table: "Zahtjev",
                column: "klijentId",
                principalTable: "Klijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
