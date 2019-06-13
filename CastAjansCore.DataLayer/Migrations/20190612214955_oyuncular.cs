using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meslek",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YabanciDil",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meslek",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "YabanciDil",
                schema: "Cast",
                table: "Oyuncular");
        }
    }
}
