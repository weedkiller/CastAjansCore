using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class dogumtarihi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                schema: "Sistem",
                table: "Kisiler",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DogumTarihi",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
