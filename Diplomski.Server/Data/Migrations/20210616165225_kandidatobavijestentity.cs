using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class kandidatobavijestentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "KandidatObavijest");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KandidatObavijest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
