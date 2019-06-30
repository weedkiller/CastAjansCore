using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ehliyet",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SskDurumu",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ehliyet",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "SskDurumu",
                schema: "Cast",
                table: "Oyuncular");
        }
    }
}
