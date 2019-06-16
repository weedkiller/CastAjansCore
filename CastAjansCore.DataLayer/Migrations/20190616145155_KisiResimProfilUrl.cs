using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class KisiResimProfilUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilFotoUrl",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.AddColumn<string>(
                name: "ProfilFotoUrl",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilFotoUrl",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.AddColumn<string>(
                name: "ProfilFotoUrl",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 100,
                nullable: true);
        }
    }
}
