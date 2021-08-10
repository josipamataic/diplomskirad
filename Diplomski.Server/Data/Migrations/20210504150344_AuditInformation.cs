using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class AuditInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VrijemePrijave",
                table: "Prijava",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Oglas",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Obavijest",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Prijava",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Prijava",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Prijava",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Prijava",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Prijava",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Prijava",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Pitanje",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Pitanje",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Pitanje",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Pitanje",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Pitanje",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Pitanje",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Pitanje",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Oglas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Oglas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Oglas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Oglas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Oglas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Oglas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Odgovor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Odgovor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Odgovor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Odgovor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Odgovor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Odgovor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Odgovor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Obavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Obavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Obavijest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Obavijest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Obavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Obavijest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "KandidatObavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "KandidatObavijest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "KandidatObavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "KandidatObavijest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KandidatObavijest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "KandidatObavijest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "KandidatObavijest",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Prijava");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Pitanje");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Prijava",
                newName: "VrijemePrijave");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Oglas",
                newName: "Datum");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Obavijest",
                newName: "Datum");
        }
    }
}
