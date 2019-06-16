using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncuResimProfilUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                schema: "Cast",
                table: "OyuncuResimleri");

            migrationBuilder.AddColumn<string>(
                name: "ProfilFotoUrl",
                schema: "Cast",
                table: "Oyuncular",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilFotoUrl",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.AddColumn<bool>(
                name: "Default",
                schema: "Cast",
                table: "OyuncuResimleri",
                nullable: false,
                defaultValue: false);
        }
    }
}
