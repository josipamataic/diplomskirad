using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class KorisnikPoslodavacProfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prezime",
                table: "AspNetUsers",
                newName: "KandidatProfil_Prezime");

            migrationBuilder.RenameColumn(
                name: "Opis",
                table: "AspNetUsers",
                newName: "PoslodavacProfil_Opis");

            migrationBuilder.RenameColumn(
                name: "Obrazovanje",
                table: "AspNetUsers",
                newName: "KandidatProfil_Obrazovanje");

            migrationBuilder.RenameColumn(
                name: "NazivFirme",
                table: "AspNetUsers",
                newName: "PoslodavacProfil_NazivFirme");

            migrationBuilder.RenameColumn(
                name: "Kontakt",
                table: "AspNetUsers",
                newName: "PoslodavacProfil_Kontakt");

            migrationBuilder.RenameColumn(
                name: "Industrija",
                table: "AspNetUsers",
                newName: "KandidatProfil_Industrija");

            migrationBuilder.RenameColumn(
                name: "Ime",
                table: "AspNetUsers",
                newName: "KandidatProfil_Ime");

            migrationBuilder.RenameColumn(
                name: "DatumRodenja",
                table: "AspNetUsers",
                newName: "KandidatProfil_DatumRodenja");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KandidatProfil_DatumRodenja",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<bool>(
                name: "PrivatniProfil",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivatniProfil",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "PoslodavacProfil_Opis",
                table: "AspNetUsers",
                newName: "Opis");

            migrationBuilder.RenameColumn(
                name: "PoslodavacProfil_NazivFirme",
                table: "AspNetUsers",
                newName: "NazivFirme");

            migrationBuilder.RenameColumn(
                name: "PoslodavacProfil_Kontakt",
                table: "AspNetUsers",
                newName: "Kontakt");

            migrationBuilder.RenameColumn(
                name: "KandidatProfil_Prezime",
                table: "AspNetUsers",
                newName: "Prezime");

            migrationBuilder.RenameColumn(
                name: "KandidatProfil_Obrazovanje",
                table: "AspNetUsers",
                newName: "Obrazovanje");

            migrationBuilder.RenameColumn(
                name: "KandidatProfil_Industrija",
                table: "AspNetUsers",
                newName: "Industrija");

            migrationBuilder.RenameColumn(
                name: "KandidatProfil_Ime",
                table: "AspNetUsers",
                newName: "Ime");

            migrationBuilder.RenameColumn(
                name: "KandidatProfil_DatumRodenja",
                table: "AspNetUsers",
                newName: "DatumRodenja");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumRodenja",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
