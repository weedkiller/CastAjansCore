using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CastAjansCore.DataLayer.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sistem");

            migrationBuilder.EnsureSchema(
                name: "Cast");

            migrationBuilder.CreateTable(
                name: "Bankalar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bankalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firmalar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Iller",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uyruklar",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyruklar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilceler",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 200, nullable: false),
                    IlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilceler", x => x.Id);
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
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Adi = table.Column<string>(maxLength: 200, nullable: false),
                    LogoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Telefon = table.Column<string>(maxLength: 13, nullable: true),
                    Telefon2 = table.Column<string>(maxLength: 13, nullable: true),
                    Faks = table.Column<string>(maxLength: 13, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    EPosta = table.Column<string>(maxLength: 200, nullable: true),
                    Adres = table.Column<string>(maxLength: 100, nullable: true),
                    IlceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musteriler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalSchema: "Sistem",
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                schema: "Sistem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    TC = table.Column<string>(maxLength: 11, nullable: true),
                    Adi = table.Column<string>(maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(maxLength: 50, nullable: false),
                    ProfilFotoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    DogumTarihi = table.Column<DateTime>(nullable: true),
                    Cinsiyet = table.Column<int>(nullable: true),
                    KanGrubu = table.Column<int>(nullable: true),
                    AnneAdiSoyadi = table.Column<string>(maxLength: 200, nullable: true),
                    BabaAdiSoyadi = table.Column<string>(maxLength: 200, nullable: true),
                    UyrukId = table.Column<int>(nullable: true),
                    Cep = table.Column<string>(maxLength: 14, nullable: true),
                    Telefon = table.Column<string>(maxLength: 14, nullable: true),
                    Telefon2 = table.Column<string>(maxLength: 14, nullable: true),
                    Faks = table.Column<string>(maxLength: 14, nullable: true),
                    Adres = table.Column<string>(maxLength: 250, nullable: true),
                    IlceId = table.Column<int>(nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    EPosta = table.Column<string>(maxLength: 200, nullable: true),
                    WebSitesi = table.Column<string>(maxLength: 100, nullable: true),
                    FaceBook = table.Column<string>(maxLength: 200, nullable: true),
                    Twitter = table.Column<string>(maxLength: 200, nullable: true),
                    Instagram = table.Column<string>(maxLength: 200, nullable: true),
                    Linkedin = table.Column<string>(maxLength: 200, nullable: true),
                    BankaId = table.Column<int>(nullable: true),
                    SubeKodu = table.Column<string>(maxLength: 4, nullable: true),
                    HesapNumarasi = table.Column<string>(maxLength: 20, nullable: true),
                    Iban = table.Column<string>(maxLength: 35, nullable: true),
                    KimlikOnUrl = table.Column<string>(maxLength: 200, nullable: true),
                    KimlikArkaUrl = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kisiler_Ilceler_IlceId",
                        column: x => x.IlceId,
                        principalSchema: "Sistem",
                        principalTable: "Ilceler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Id = table.Column<int>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    Boy = table.Column<int>(nullable: true),
                    Kilo = table.Column<int>(nullable: true),
                    AltBeden = table.Column<int>(nullable: true),
                    UstBeden = table.Column<int>(nullable: true),
                    AyakNumarasi = table.Column<int>(nullable: true),
                    GozRengi = table.Column<int>(nullable: true),
                    TenRengi = table.Column<int>(nullable: true),
                    SacRengi = table.Column<int>(nullable: true),
                    Meslek = table.Column<string>(maxLength: 200, nullable: true),
                    YabanciDil = table.Column<string>(maxLength: 200, nullable: true),
                    EngelDurumu = table.Column<string>(maxLength: 200, nullable: true),
                    OyuculukEgitimi = table.Column<string>(maxLength: 4000, nullable: true),
                    Tecrubeler = table.Column<string>(maxLength: 4000, nullable: true),
                    Yetenekleri = table.Column<string>(maxLength: 4000, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    Kase = table.Column<decimal>(nullable: true),
                    SskDurumu = table.Column<string>(maxLength: 200, nullable: true),
                    Ehliyet = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oyuncular_Kisiler_Id",
                        column: x => x.Id,
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
                    Id = table.Column<int>(nullable: false),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    KullaniciAdi = table.Column<string>(maxLength: 20, nullable: false),
                    Rol = table.Column<int>(nullable: false),
                    Sifre = table.Column<string>(maxLength: 20, nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Kisiler_Id",
                        column: x => x.Id,
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
                    EkleyenId = table.Column<int>(nullable: true),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: false),
                    DosyaYolu = table.Column<string>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuResimleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OyuncuResimleri_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OyuncuVideolari",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: false),
                    DosyaYolu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyuncuVideolari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OyuncuVideolari_Oyuncular_OyuncuId",
                        column: x => x.OyuncuId,
                        principalSchema: "Cast",
                        principalTable: "Oyuncular",
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
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    MusteriId = table.Column<int>(nullable: false),
                    ProjeDurumu = table.Column<int>(nullable: false),
                    TarihBas = table.Column<DateTime>(nullable: false),
                    TarihBit = table.Column<DateTime>(nullable: false),
                    Adi = table.Column<string>(maxLength: 50, nullable: true),
                    IsTipi = table.Column<int>(nullable: false),
                    Mecra = table.Column<int>(nullable: false),
                    EPostaAdresleri = table.Column<string>(maxLength: 4000, nullable: true),
                    Aciklama = table.Column<string>(maxLength: 4000, nullable: true),
                    IsiTakipEdenId = table.Column<int>(nullable: false),
                    TeklifAciklama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projeler_Kullanicilar_IsiTakipEdenId",
                        column: x => x.IsiTakipEdenId,
                        principalSchema: "Sistem",
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projeler_Musteriler_MusteriId",
                        column: x => x.MusteriId,
                        principalSchema: "Cast",
                        principalTable: "Musteriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjeKarakterleri",
                schema: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
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
                    EkleyenId = table.Column<int>(nullable: true),
                    EklemeZamani = table.Column<DateTime>(nullable: false),
                    GuncelleyenId = table.Column<int>(nullable: true),
                    GuncellemeZamani = table.Column<DateTime>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    ProjeKarakterId = table.Column<int>(nullable: false),
                    OyuncuId = table.Column<int>(nullable: false),
                    KarakterDurumu = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeKarakterOyunculari", x => x.Id);
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

            migrationBuilder.InsertData(
                schema: "Sistem",
                table: "Kisiler",
                columns: new[] { "Id", "Aciklama", "Adi", "Adres", "Aktif", "AnneAdiSoyadi", "BabaAdiSoyadi", "BankaId", "Cep", "Cinsiyet", "DogumTarihi", "EPosta", "EklemeZamani", "EkleyenId", "FaceBook", "Faks", "GuncellemeZamani", "GuncelleyenId", "HesapNumarasi", "Iban", "IlceId", "Instagram", "KanGrubu", "KimlikArkaUrl", "KimlikOnUrl", "Linkedin", "ProfilFotoUrl", "Soyadi", "SubeKodu", "TC", "Telefon", "Telefon2", "Twitter", "UyrukId", "WebSitesi" },
                values: new object[] { 1, null, "Admin", null, true, null, null, null, null, null, null, null, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, null, null, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, null, null, null, null, null, null, null, null, null, "Soyadi", null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "Sistem",
                table: "Kullanicilar",
                columns: new[] { "Id", "Aktif", "EklemeZamani", "EkleyenId", "GuncellemeZamani", "GuncelleyenId", "KullaniciAdi", "Rol", "Sifre", "Token" },
                values: new object[] { 1, true, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2019, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 1, "admin", 1, "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Musteriler_IlceId",
                schema: "Cast",
                table: "Musteriler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuResimleri_OyuncuId",
                schema: "Cast",
                table: "OyuncuResimleri",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_OyuncuVideolari_OyuncuId",
                schema: "Cast",
                table: "OyuncuVideolari",
                column: "OyuncuId");

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
                name: "IX_ProjeKarakterOyunculari_OyuncuId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "OyuncuId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeKarakterOyunculari_ProjeKarakterId",
                schema: "Cast",
                table: "ProjeKarakterOyunculari",
                column: "ProjeKarakterId");

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
                name: "IX_Ilceler_IlId",
                schema: "Sistem",
                table: "Ilceler",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_IlceId",
                schema: "Sistem",
                table: "Kisiler",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_UyrukId",
                schema: "Sistem",
                table: "Kisiler",
                column: "UyrukId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OyuncuResimleri",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "OyuncuVideolari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "ProjeKarakterOyunculari",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Bankalar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Firmalar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "ProjeKarakterleri",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Oyuncular",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Projeler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Kullanicilar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Musteriler",
                schema: "Cast");

            migrationBuilder.DropTable(
                name: "Kisiler",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Ilceler",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Uyruklar",
                schema: "Sistem");

            migrationBuilder.DropTable(
                name: "Iller",
                schema: "Sistem");
        }
    }
}
