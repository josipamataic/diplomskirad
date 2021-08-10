using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class IndustrijaUserOglas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndustrijaId",
                table: "Oglas",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.AddColumn<int>(
                name: "IndustrijaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_IndustrijaId",
                table: "Oglas",
                column: "IndustrijaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IndustrijaId",
                table: "AspNetUsers",
                column: "IndustrijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Industrija_IndustrijaId",
                table: "AspNetUsers",
                column: "IndustrijaId",
                principalTable: "Industrija",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_Industrija_IndustrijaId",
                table: "Oglas",
                column: "IndustrijaId",
                principalTable: "Industrija",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Industrija_IndustrijaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Oglas_Industrija_IndustrijaId",
                table: "Oglas");

            migrationBuilder.DropIndex(
                name: "IX_Oglas_IndustrijaId",
                table: "Oglas");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IndustrijaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IndustrijaId",
                table: "Oglas");

            migrationBuilder.DropColumn(
                name: "IndustrijaId",
                table: "AspNetUsers");
        }
    }
}
