using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class kullanici_banka_telefon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiBankalari",
                schema: "Sistem");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BankaId",
                schema: "Sistem",
                table: "Kisiler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Faks",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HesapNumarasi",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubeKodu",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon2",
                schema: "Sistem",
                table: "Kisiler",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon2",
                schema: "Cast",
                table: "Musteriler",
                maxLength: 13,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "BankaId",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Faks",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "HesapNumarasi",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Iban",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "SubeKodu",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Telefon",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Telefon2",
                schema: "Sistem",
                table: "Kisiler");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.DropColumn(
                name: "Telefon2",
                schema: "Cast",
                table: "Musteriler");

            migrationBuilder.CreateTable(
                name: "KisiBankalari",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktif = table.Column<bool>(nullable: false),
                    BankaId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    HesapNumarasi = table.Column<string>(nullable: true),
                    Iban = table.Column<string>(nullable: true),
                    KisiId = table.Column<int>(nullable: false),
                    SubeKodu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiBankalari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisiBankalari_Bankalar_BankaId",
                        column: x => x.BankaId,
                        principalSchema: "Sistem",
                        principalTable: "Bankalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KisiBankalari_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KisiBankalari_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KisiBankalari_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisiBankalari_BankaId",
                schema: "Sistem",
                table: "KisiBankalari",
                column: "BankaId");

            migrationBuilder.CreateIndex(
                name: "IX_KisiBankalari_EkleyenId",
                schema: "Sistem",
                table: "KisiBankalari",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_KisiBankalari_GuncelleyenId",
                schema: "Sistem",
                table: "KisiBankalari",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_KisiBankalari_KisiId",
                schema: "Sistem",
                table: "KisiBankalari",
                column: "KisiId");
        }
    }
}
