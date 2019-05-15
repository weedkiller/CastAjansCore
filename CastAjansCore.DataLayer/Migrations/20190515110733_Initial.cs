using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sistem");

            migrationBuilder.EnsureSchema(
                name: "Cast");

            migrationBuilder.CreateTable(
                name: "EngelDurumlari",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngelDurumlari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uyruklar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adi = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyruklar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TC = table.Column<string>(maxLength: 11, nullable: true),
                    Adi = table.Column<string>(maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<string>(nullable: true),
                    Cinsiyet = table.Column<int>(nullable: false),
                    KanGrubu = table.Column<int>(nullable: false),
                    UyrukId = table.Column<int>(nullable: false),
                    EPosta = table.Column<string>(maxLength: 200, nullable: true),
                    WebSitesi = table.Column<string>(maxLength: 100, nullable: true),
                    FaceBook = table.Column<string>(maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(maxLength: 200, nullable: true),
                    Instagram = table.Column<string>(maxLength: 200, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kisiler_Uyruklar_UyrukId",
                        column: x => x.UyrukId,
                        principalSchema: "Sistem",
                        principalTable: "Uyruklar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                schema: "Cast",
                columns: table => new
                {
                    KisiId = table.Column<int>(nullable: false),
                    AnneAdiSoyadi = table.Column<string>(nullable: true),
                    BabaAdiSoyadi = table.Column<string>(nullable: true),
                    Boy = table.Column<int>(nullable: false),
                    Kilo = table.Column<int>(nullable: false),
                    AltBeden = table.Column<string>(maxLength: 20, nullable: true),
                    UstBeden = table.Column<string>(maxLength: 20, nullable: true),
                    AyakNumarasi = table.Column<int>(nullable: false),
                    GozRengi = table.Column<int>(nullable: false),
                    TenRengi = table.Column<int>(nullable: false),
                    SacRengi = table.Column<int>(nullable: false),
                    EngelDurumuId = table.Column<int>(nullable: false),
                    OyuculukEgitimi = table.Column<string>(maxLength: 4000, nullable: true),
                    Tecrubeler = table.Column<string>(maxLength: 4000, nullable: true),
                    Yetenekleri = table.Column<string>(maxLength: 4000, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    Kase = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.KisiId);
                    table.ForeignKey(
                        name: "FK_Oyuncular_EngelDurumlari_EngelDurumuId",
                        column: x => x.EngelDurumuId,
                        principalSchema: "Cast",
                        principalTable: "EngelDurumlari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oyuncular_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supervisorler",
                schema: "Cast",
                columns: table => new
                {
                    KisiId = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisorler", x => x.KisiId);
                    table.ForeignKey(
                        name: "FK_Supervisorler_Kisiler_KisiId",
                        column: x => x.KisiId,
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
                name: "Bankalar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bankalar_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bankalar_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Firmalar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: false),
                    LogoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 20, nullable: true),
                    Faks = table.Column<string>(maxLength: 20, nullable: true),
                    EPosta = table.Column<string>(maxLength: 200, nullable: true),
                    FaceBook = table.Column<string>(maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(maxLength: 200, nullable: true),
                    Instagram = table.Column<string>(maxLength: 200, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firmalar_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Firmalar_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iller",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Iller_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Iller_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                schema: "Sistem",
                columns: table => new
                {
                    KisiId = table.Column<int>(nullable: false),
                    Sifre = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KisiId);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Kisiler_KisiId",
                        column: x => x.KisiId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OyuncuResimleri",
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
                    OyuncuId = table.Column<int>(nullable: false),
                    DosyaYolu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuResimleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OyuncuResimleri_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OyuncuResimleri_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OyuncuResimleri_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OyuncuVideolari",
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
                    OyuncuId = table.Column<int>(nullable: false),
                    DosyaYolu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuVideolari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OyuncuVideolari_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OyuncuVideolari_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OyuncuVideolari_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KisiBankalari",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    KisiId = table.Column<int>(nullable: false),
                    BankaId = table.Column<int>(nullable: false),
                    SubeKodu = table.Column<string>(nullable: true),
                    HesapNumarasi = table.Column<string>(nullable: true),
                    Iban = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Ilceler",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: false),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 200, nullable: false),
                    IlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilceler_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ilceler_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ilceler_Iller_IlId",
                        column: x => x.IlId,
                        principalSchema: "Sistem",
                        principalTable: "Iller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
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
                    Adi = table.Column<string>(maxLength: 200, nullable: false),
                    LogoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 100, nullable: true),
                    Faks = table.Column<string>(maxLength: 100, nullable: true),
                    EPosta = table.Column<string>(maxLength: 200, nullable: true),
                    Adres = table.Column<string>(maxLength: 100, nullable: true),
                    IlceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musteriler_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Musteriler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalSchema: "Sistem",
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
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
                    MusteriId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    IsTipi = table.Column<int>(nullable: false),
                    Mecra = table.Column<int>(nullable: false),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    Konu = table.Column<string>(maxLength: 4000, nullable: true),
                    SupervisorId = table.Column<int>(nullable: false),
                    IsiTakipEdenId = table.Column<int>(nullable: false),
                    YonetmenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeler_Kisiler_EkleyenId",
                        column: x => x.EkleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Kisiler_GuncelleyenId",
                        column: x => x.GuncelleyenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Kisiler_IsiTakipEdenId",
                        column: x => x.IsiTakipEdenId,
                        principalSchema: "Sistem",
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalSchema: "Cast",
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Supervisorler_SupervisorId",
                        column: x => x.SupervisorId,
                        principalSchema: "Cast",
                        principalTable: "Supervisorler",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Yonetmenler_YonetmenId",
                        column: x => x.YonetmenId,
                        principalSchema: "Cast",
                        principalTable: "Yonetmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bolumler",
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
                    Konu = table.Column<string>(maxLength: 4000, nullable: true),
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
                name: "BolumKarakterleri",
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
                    BolumId = table.Column<int>(nullable: false),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    KarakterSayisi = table.Column<int>(nullable: false),
                    OyuncuKisiId = table.Column<int>(nullable: true)
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
                        name: "FK_BolumKarakterleri_Oyuncular_OyuncuKisiId",
                        column: x => x.OyuncuKisiId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BolumKarakterOyunculari",
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
                    BolumKarakterId = table.Column<int>(nullable: false),
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
                        principalColumn: "KisiId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_BolumKarakterleri_OyuncuKisiId",
                schema: "Cast",
                table: "BolumKarakterleri",
                column: "OyuncuKisiId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_IlceId",
                schema: "Cast",
                table: "Musteriler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Oyuncular_EngelDurumuId",
                schema: "Cast",
                table: "Oyuncular",
                column: "EngelDurumuId");

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
                name: "IX_OyuncuResimleri_OyuncuId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "OyuncuId");

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
                name: "IX_OyuncuVideolari_OyuncuId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "OyuncuId");

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
                name: "IX_Projeler_IsiTakipEdenId",
                schema: "Cast",
                table: "Projeler",
                column: "IsiTakipEdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Projeler_MusteriId",
                schema: "Cast",
                table: "Projeler",
                column: "MusteriId");

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
                name: "IX_Ilceler_EkleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "EkleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_GuncelleyenId",
                schema: "Sistem",
                table: "Ilceler",
                column: "GuncelleyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilceler_IlId",
                schema: "Sistem",
                table: "Ilceler",
                column: "IlId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_UyrukId",
                schema: "Sistem",
                table: "Kisiler",
                column: "UyrukId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BolumKarakterOyunculari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "OyuncuResimleri",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "OyuncuVideolari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Firmalar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "KisiBankalari",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Kullanicilar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "BolumKarakterleri",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Bankalar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Bolumler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Oyuncular",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Projeler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "EngelDurumlari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Musteriler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Supervisorler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Yonetmenler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Ilceler",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Iller",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Kisiler",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Uyruklar",
                schema: "Sistem");
        }
    }
}
