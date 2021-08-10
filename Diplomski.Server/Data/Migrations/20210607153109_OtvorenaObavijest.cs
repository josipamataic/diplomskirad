using Microsoft.EntityFrameworkCore.Migrations;

namespace Diplomski.Server.Data.Migrations
{
    public partial class OtvorenaObavijest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Otvoreno",
                table: "KandidatObavijest",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Otvoreno",
                table: "KandidatObavijest");
        }
    }
}
