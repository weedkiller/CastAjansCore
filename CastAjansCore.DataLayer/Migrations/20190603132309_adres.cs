using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class adres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ilceler_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilceler_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropForeignKey(
                name: "FK_Iller_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropForeignKey(
                name: "FK_Iller_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropIndex(
                name: "IX_Iller_EkleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropIndex(
                name: "IX_Iller_GuncelleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropIndex(
                name: "IX_Ilceler_EkleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropIndex(
                name: "IX_Ilceler_GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IlceId",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Firmalar",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Bankalar",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Projeler",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "Projeler",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Musteriler",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "Musteriler",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_IlceId",
                schema: "Sistem",
                table: "Kisiler",
                column: "IlceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Ilceler_IlceId",
                schema: "Sistem",
                table: "Kisiler",
                column: "IlceId",
                principalSchema: "Sistem",
                principalTable: "Ilceler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Ilceler_IlceId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropIndex(
                name: "IX_Kisiler_IlceId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Adres",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "IlceId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Sistem",
                table: "Iller",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Iller",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Iller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Iller",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Iller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Sistem",
                table: "Ilceler",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Ilceler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Ilceler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Ilceler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Firmalar",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Bankalar",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Musteriler",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "Musteriler",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iller_EkleyenId",
                schema: "Sistem",
                table: "Iller",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Iller_GuncelleyenId",
                schema: "Sistem",
                table: "Iller",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_EkleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "GuncelleyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ilceler_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ilceler_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iller_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Iller",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iller_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Iller",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
