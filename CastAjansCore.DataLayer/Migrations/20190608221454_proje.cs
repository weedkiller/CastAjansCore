using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class proje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YonetmenId",
                schema: "Cast",
                table: "Projeler");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YonetmenId",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                defaultValue: 0);
        }
    }
}
