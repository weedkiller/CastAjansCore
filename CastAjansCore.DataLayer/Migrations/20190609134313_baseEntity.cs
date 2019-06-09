using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class baseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Kisiler_EkleyenId",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_Musteriler_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.DropForeignKey(
                name: "FK_OyuncuResimleri_Kisiler_EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri");

            migrationBuilder.DropForeignKey(
                name: "FK_OyuncuResimleri_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri");

            migrationBuilder.DropForeignKey(
                name: "FK_OyuncuVideolari_Kisiler_EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari");

            migrationBuilder.DropForeignKey(
                name: "FK_OyuncuVideolari_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjeKarakterleri_Kisiler_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjeKarakterleri_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjeKarakterOyunculari_Kisiler_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjeKarakterOyunculari_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Kisiler_EkleyenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Bankalar_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Bankalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Bankalar_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Firmalar_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Firmalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Firmalar_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar");

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

            migrationBuilder.DropIndex(
                name: "IX_Firmalar_EkleyenId",
                schema: "Sistem",
                table: "Firmalar");

            migrationBuilder.DropIndex(
                name: "IX_Firmalar_GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar");

            migrationBuilder.DropIndex(
                name: "IX_Bankalar_EkleyenId",
                schema: "Sistem",
                table: "Bankalar");

            migrationBuilder.DropIndex(
                name: "IX_Bankalar_GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar");

            migrationBuilder.DropIndex(
                name: "IX_Projeler_EkleyenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropIndex(
                name: "IX_Projeler_GuncelleyenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropIndex(
                name: "IX_ProjeKarakterOyunculari_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari");

            migrationBuilder.DropIndex(
                name: "IX_ProjeKarakterOyunculari_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari");

            migrationBuilder.DropIndex(
                name: "IX_ProjeKarakterleri_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri");

            migrationBuilder.DropIndex(
                name: "IX_ProjeKarakterleri_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri");

            migrationBuilder.DropIndex(
                name: "IX_OyuncuVideolari_EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari");

            migrationBuilder.DropIndex(
                name: "IX_OyuncuVideolari_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari");

            migrationBuilder.DropIndex(
                name: "IX_OyuncuResimleri_EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri");

            migrationBuilder.DropIndex(
                name: "IX_OyuncuResimleri_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_EkleyenId",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.DropIndex(
                name: "IX_Musteriler_GuncelleyenId",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Sistem",
                table: "Uyruklar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Uyruklar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Uyruklar",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Uyruklar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Uyruklar",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Kullanicilar",
                nullable: true);

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
                nullable: true);

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
                nullable: true);

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
                nullable: true);

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
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklemeZamani",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenId",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeZamani",
                schema: "Cast",
                table: "Oyuncular",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Oyuncular",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Sistem",
                table: "Uyruklar");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Uyruklar");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Uyruklar");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Uyruklar");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Uyruklar");

            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Sistem",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Sistem",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Sistem",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Sistem",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Sistem",
                table: "Kullanicilar");

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

            migrationBuilder.DropColumn(
                name: "Aktif",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "EklemeZamani",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "EkleyenId",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "GuncellemeZamani",
                schema: "Cast",
                table: "Oyuncular");

            migrationBuilder.DropColumn(
                name: "GuncelleyenId",
                schema: "Cast",
                table: "Oyuncular");

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

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_EkleyenId",
                schema: "Sistem",
                table: "Firmalar",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Bankalar_EkleyenId",
                schema: "Sistem",
                table: "Bankalar",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Bankalar_GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_EkleyenId",
                schema: "Cast",
                table: "Projeler",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_GuncelleyenId",
                schema: "Cast",
                table: "Projeler",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterOyunculari_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterOyunculari_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterleri_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterleri_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuVideolari_EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuVideolari_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuResimleri_EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuResimleri_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_EkleyenId",
                schema: "Cast",
                table: "Musteriler",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_GuncelleyenId",
                schema: "Cast",
                table: "Musteriler",
                column: "GuncelleyenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Kisiler_EkleyenId",
                schema: "Cast",
                table: "Musteriler",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musteriler_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "Musteriler",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OyuncuResimleri_Kisiler_EkleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OyuncuResimleri_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OyuncuVideolari_Kisiler_EkleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OyuncuVideolari_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjeKarakterleri_Kisiler_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjeKarakterleri_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjeKarakterOyunculari_Kisiler_EkleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjeKarakterOyunculari_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Kisiler_EkleyenId",
                schema: "Cast",
                table: "Projeler",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Kisiler_GuncelleyenId",
                schema: "Cast",
                table: "Projeler",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bankalar_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Bankalar",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bankalar_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Bankalar",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Firmalar_Kisiler_EkleyenId",
                schema: "Sistem",
                table: "Firmalar",
                column: "EkleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Firmalar_Kisiler_GuncelleyenId",
                schema: "Sistem",
                table: "Firmalar",
                column: "GuncelleyenId",
                principalSchema: "Sistem",
                principalTable: "Kisiler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
