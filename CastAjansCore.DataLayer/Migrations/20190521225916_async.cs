using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class async : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Supervisorler_SupervisorId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeler_Yonetmenler_YonetmenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropTable(
                name: "BolumKarakterOyunculari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Supervisorler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Yonetmenler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "BolumKarakterleri",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Bolumler",
                schema: "Cast");

            migrationBuilder.DropIndex(
                name: "IX_Projeler_SupervisorId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropIndex(
                name: "IX_Projeler_YonetmenId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "Konu",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.AddColumn<DateTime>(
                name: "TarihBas",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TarihBit",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TeklifAciklama",
                schema: "Cast",
                table: "Projeler",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjeKarakterleri",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    ProjeId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    KarakterSayisi = table.Column<int>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeKarakterleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterleri_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterleri_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterleri_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterleri_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalSchema: "Cast",
                        principalTable: "Projeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjeKarakterOyunculari",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    ProjeKarakterId = table.Column<int>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: false),
                    karakterDurumu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeKarakterOyunculari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterOyunculari_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterOyunculari_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterOyunculari_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjeKarakterOyunculari_ProjeKarakterleri_ProjeKarakterId",
                        column: x => x.ProjeKarakterId,
                        principalSchema: "Cast",
                        principalTable: "ProjeKarakterleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_ProjeKarakterleri_OyuncuId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterleri_ProjeId",
                schema: "Cast",
                table: "ProjeKarakterleri",
                column: "ProjeId");

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
                name: "IX_ProjeKarakterOyunculari_OyuncuId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterOyunculari_ProjeKarakterId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "ProjeKarakterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjeKarakterOyunculari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "ProjeKarakterleri",
                schema: "Cast");

            migrationBuilder.DropColumn(
                name: "TarihBas",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "TarihBit",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.DropColumn(
                name: "TeklifAciklama",
                schema: "Cast",
                table: "Projeler");

            migrationBuilder.AddColumn<string>(
                name: "Konu",
                schema: "Cast",
                table: "Projeler",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                schema: "Cast",
                table: "Projeler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Bolumler",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    Konu = table.Column<string>(maxLength: 4000, nullable: true),
                    ProjeId = table.Column<int>(nullable: false),
                    TarihBas = table.Column<DateTime>(nullable: false),
                    TarihBit = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolumler_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bolumler_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bolumler_Projeler_ProjeId",
                        column: x => x.ProjeId,
                        principalSchema: "Cast",
                        principalTable: "Projeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisorler",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisorler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supervisorler_Kisiler_Id",
                        column: x => x.Id,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yonetmenler",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetmenler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yonetmenler_Kisiler_Id",
                        column: x => x.Id,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BolumKarakterleri",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    BolumId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    KarakterSayisi = table.Column<int>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumKarakterleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BolumKarakterleri_Bolumler_BolumId",
                        column: x => x.BolumId,
                        principalSchema: "Cast",
                        principalTable: "Bolumler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterleri_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterleri_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterleri_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BolumKarakterOyunculari",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktif = table.Column<bool>(nullable: false),
                    BolumKarakterId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: false),
                    Secildi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumKarakterOyunculari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BolumKarakterOyunculari_BolumKarakterleri_BolumKarakterId",
                        column: x => x.BolumKarakterId,
                        principalSchema: "Cast",
                        principalTable: "BolumKarakterleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterOyunculari_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterOyunculari_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BolumKarakterOyunculari_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_SupervisorId",
                schema: "Cast",
                table: "Projeler",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_YonetmenId",
                schema: "Cast",
                table: "Projeler",
                column: "YonetmenId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterleri_BolumId",
                schema: "Cast",
                table: "BolumKarakterleri",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterleri_EkleyenId",
                schema: "Cast",
                table: "BolumKarakterleri",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterleri_GuncelleyenId",
                schema: "Cast",
                table: "BolumKarakterleri",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterleri_OyuncuId",
                schema: "Cast",
                table: "BolumKarakterleri",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterOyunculari_BolumKarakterId",
                schema: "Cast",
                table: "BolumKarakterOyunculari",
                column: "BolumKarakterId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterOyunculari_EkleyenId",
                schema: "Cast",
                table: "BolumKarakterOyunculari",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterOyunculari_GuncelleyenId",
                schema: "Cast",
                table: "BolumKarakterOyunculari",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_BolumKarakterOyunculari_OyuncuId",
                schema: "Cast",
                table: "BolumKarakterOyunculari",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_EkleyenId",
                schema: "Cast",
                table: "Bolumler",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_GuncelleyenId",
                schema: "Cast",
                table: "Bolumler",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_ProjeId",
                schema: "Cast",
                table: "Bolumler",
                column: "ProjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Supervisorler_SupervisorId",
                schema: "Cast",
                table: "Projeler",
                column: "SupervisorId",
                principalSchema: "Cast",
                principalTable: "Supervisorler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projeler_Yonetmenler_YonetmenId",
                schema: "Cast",
                table: "Projeler",
                column: "YonetmenId",
                principalSchema: "Cast",
                principalTable: "Yonetmenler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
