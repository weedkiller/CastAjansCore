using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class Ilce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IlceId",
                schema: "Cast",
                table: "Musteriler",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IlceId",
                schema: "Cast",
                table: "Musteriler",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
