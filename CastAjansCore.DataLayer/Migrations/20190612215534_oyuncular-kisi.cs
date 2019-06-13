using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncularkisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnneAdiSoyadi",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "BabaAdiSoyadi",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.AddColumn<string>(
                name: "AnneAdiSoyadi",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BabaAdiSoyadi",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnneAdiSoyadi",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "BabaAdiSoyadi",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.AddColumn<string>(
                name: "AnneAdiSoyadi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BabaAdiSoyadi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);
        }
    }
}
