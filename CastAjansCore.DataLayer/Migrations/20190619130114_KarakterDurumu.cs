using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class KarakterDurumu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "karakterDurumu",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                newName: "KarakterDurumu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KarakterDurumu",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                newName: "karakterDurumu");
        }
    }
}
