using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyRentifyAplikacija.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrvaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    brojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visina = table.Column<double>(type: "float", nullable: false),
                    nivoVjestine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oprema",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    materijal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oprema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipZahtjeva",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipZahtjeva", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vlasnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    korisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlasnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumPodnosenjaZahtjeva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumIzdavanjaUsluje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumZavrsetkaUsluge = table.Column<DateTime>(type: "datetime2", nullable: false),
                    klijentId = table.Column<int>(type: "int", nullable: false),
                    cijena = table.Column<double>(type: "float", nullable: false),
                    popust = table.Column<double>(type: "float", nullable: false),
                    placeno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zahtjev_Klijent_klijentId",
                        column: x => x.klijentId,
                        principalTable: "Klijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kaciga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    velicina = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaciga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kaciga_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pancerice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    velicina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pancerice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pancerice_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    duzina = table.Column<double>(type: "float", nullable: false),
                    sirina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skije_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Snowboard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    duzina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snowboard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snowboard_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnowboardCipele",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    velicina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnowboardCipele", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnowboardCipele_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stapovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    duzina = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stapovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stapovi_Oprema_Id",
                        column: x => x.Id,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkaZahtjeva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZahtjevId = table.Column<int>(type: "int", nullable: false),
                    OpremaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaZahtjeva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkaZahtjeva_Oprema_OpremaId",
                        column: x => x.OpremaId,
                        principalTable: "Oprema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkaZahtjeva_Zahtjev_ZahtjevId",
                        column: x => x.ZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoviZahtjeva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZahtjevId = table.Column<int>(type: "int", nullable: false),
                    TipZahtjevaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoviZahtjeva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoviZahtjeva_TipZahtjeva_TipZahtjevaId",
                        column: x => x.TipZahtjevaId,
                        principalTable: "TipZahtjeva",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoviZahtjeva_Zahtjev_ZahtjevId",
                        column: x => x.ZahtjevId,
                        principalTable: "Zahtjev",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtjeva_OpremaId",
                table: "StavkaZahtjeva",
                column: "OpremaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaZahtjeva_ZahtjevId",
                table: "StavkaZahtjeva",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoviZahtjeva_TipZahtjevaId",
                table: "TipoviZahtjeva",
                column: "TipZahtjevaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoviZahtjeva_ZahtjevId",
                table: "TipoviZahtjeva",
                column: "ZahtjevId");

            migrationBuilder.CreateIndex(
                name: "IX_Zahtjev_klijentId",
                table: "Zahtjev",
                column: "klijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kaciga");

            migrationBuilder.DropTable(
                name: "Pancerice");

            migrationBuilder.DropTable(
                name: "Skije");

            migrationBuilder.DropTable(
                name: "Snowboard");

            migrationBuilder.DropTable(
                name: "SnowboardCipele");

            migrationBuilder.DropTable(
                name: "Stapovi");

            migrationBuilder.DropTable(
                name: "StavkaZahtjeva");

            migrationBuilder.DropTable(
                name: "TipoviZahtjeva");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "Vlasnik");

            migrationBuilder.DropTable(
                name: "Oprema");

            migrationBuilder.DropTable(
                name: "TipZahtjeva");

            migrationBuilder.DropTable(
                name: "Zahtjev");

            migrationBuilder.DropTable(
                name: "Klijent");
        }
    }
}
