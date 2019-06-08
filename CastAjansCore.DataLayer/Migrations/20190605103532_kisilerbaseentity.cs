using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class kisilerbaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Sistem",
                table: "Kisiler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Kisiler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Kisiler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Kisiler",
                column: "EkleyenId",
                unique: true,
                filter: "[EkleyenId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler",
                column: "GuncelleyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Kisiler",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropIndex(
                name: "IX_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropIndex(
                name: "IX_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Kisiler");
        }
    }
}
