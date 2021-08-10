using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class HardDeleteUsersStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DeletedBy",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Odgovor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Odgovor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
