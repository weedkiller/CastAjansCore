using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                schema: "Sistem",
                table: "Kullanicilar");
        }
    }
}
