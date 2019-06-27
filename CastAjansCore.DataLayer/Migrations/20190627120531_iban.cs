using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class iban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Iban",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 35,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Iban",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 35,
                oldNullable: true);
        }
    }
}
