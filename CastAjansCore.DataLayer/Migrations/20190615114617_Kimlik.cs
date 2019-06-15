using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class Kimlik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KimlikArkaUrl",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KimlikOnUrl",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KimlikArkaUrl",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "KimlikOnUrl",
                schema: "Sistem",
                table: "Kisiler");
        }
    }
}
