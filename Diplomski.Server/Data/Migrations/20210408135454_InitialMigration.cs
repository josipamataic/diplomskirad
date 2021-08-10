using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodenja",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Industrija",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Kontakt",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivFirme",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Obrazovanje",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zemlja",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Industrija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoslodavacId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglas_AspNetUsers_PoslodavacId",
                        column: x => x.PoslodavacId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOglas = table.Column<int>(type: "int", nullable: false),
                    IdPoslodavac = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obavijest_AspNetUsers_IdPoslodavac",
                        column: x => x.IdPoslodavac,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obavijest_Oglas_IdOglas",
                        column: x => x.IdOglas,
                        principalTable: "Oglas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pitanje_Oglas_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prijava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemePrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdKandidat = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdOglas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijava", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijava_AspNetUsers_IdKandidat",
                        column: x => x.IdKandidat,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prijava_Oglas_IdOglas",
                        column: x => x.IdOglas,
                        principalTable: "Oglas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KandidatObavijest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObavijestId = table.Column<int>(type: "int", nullable: false),
                    KandidatId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KandidatObavijest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KandidatObavijest_AspNetUsers_KandidatId",
                        column: x => x.KandidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KandidatObavijest_Obavijest_ObavijestId",
                        column: x => x.ObavijestId,
                        principalTable: "Obavijest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Odgovor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPItanja = table.Column<int>(type: "int", nullable: false),
                    IdKandidata = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdOglasa = table.Column<int>(type: "int", nullable: false),
                    IdPrijava = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odgovor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odgovor_AspNetUsers_IdKandidata",
                        column: x => x.IdKandidata,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odgovor_Oglas_IdOglasa",
                        column: x => x.IdOglasa,
                        principalTable: "Oglas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odgovor_Pitanje_IdPItanja",
                        column: x => x.IdPItanja,
                        principalTable: "Pitanje",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Odgovor_Prijava_IdPrijava",
                        column: x => x.IdPrijava,
                        principalTable: "Prijava",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KandidatObavijest_KandidatId",
                table: "KandidatObavijest",
                column: "KandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KandidatObavijest_ObavijestId",
                table: "KandidatObavijest",
                column: "ObavijestId");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_IdOglas",
                table: "Obavijest",
                column: "IdOglas");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_IdPoslodavac",
                table: "Obavijest",
                column: "IdPoslodavac");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_IdKandidata",
                table: "Odgovor",
                column: "IdKandidata");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_IdOglasa",
                table: "Odgovor",
                column: "IdOglasa");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_IdPItanja",
                table: "Odgovor",
                column: "IdPItanja");

            migrationBuilder.CreateIndex(
                name: "IX_Odgovor_IdPrijava",
                table: "Odgovor",
                column: "IdPrijava");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_PoslodavacId",
                table: "Oglas",
                column: "PoslodavacId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_OglasId",
                table: "Pitanje",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijava_IdKandidat",
                table: "Prijava",
                column: "IdKandidat");

            migrationBuilder.CreateIndex(
                name: "IX_Prijava_IdOglas",
                table: "Prijava",
                column: "IdOglas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KandidatObavijest");

            migrationBuilder.DropTable(
                name: "Odgovor");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "Prijava");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropColumn(
                name: "DatumRodenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Industrija",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Kontakt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NazivFirme",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Obrazovanje",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Zemlja",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
