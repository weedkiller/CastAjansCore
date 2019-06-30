using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class oyuncu_enu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SacRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GozRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TenRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SacRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GozRengi",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
