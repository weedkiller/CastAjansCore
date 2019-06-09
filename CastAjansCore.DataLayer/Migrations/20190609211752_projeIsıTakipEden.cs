using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class projeIsıTakipEden : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Kisiler_IsiTakipEdenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Kullanicilar_IsiTakipEdenId",
                schema: "Cast",
                table: "Projeler",
                column: "IsiTakipEdenId",
                principalSchema: "Sistem",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Kullanicilar_IsiTakipEdenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Kisiler_IsiTakipEdenId",
                schema: "Cast",
                table: "Projeler",
                column: "IsiTakipEdenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
