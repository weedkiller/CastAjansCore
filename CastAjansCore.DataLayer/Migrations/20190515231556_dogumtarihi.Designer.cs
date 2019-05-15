﻿// <auto-generated />
using System;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CastAjansCore.DataLayer.Migrations
{
    [DbContext(typeof(CastAjansContext))]
    [Migration("20190515231556_dogumtarihi")]
    partial class dogumtarihi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastAjansCore.Entity.Banka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.ToTable("Bankalar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Bolum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("Adi")
                        .HasMaxLength(50);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<string>("Konu")
                        .HasMaxLength(4000);

                    b.Property<int>("ProjeId");

                    b.Property<DateTime>("TarihBas");

                    b.Property<DateTime>("TarihBit");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("ProjeId");

                    b.ToTable("Bolumler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.BolumKarakter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("Adi")
                        .HasMaxLength(50);

                    b.Property<bool>("Aktif");

                    b.Property<int>("BolumId");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("KarakterSayisi");

                    b.Property<int?>("OyuncuId");

                    b.HasKey("Id");

                    b.HasIndex("BolumId");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("OyuncuId");

                    b.ToTable("BolumKarakterleri","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.BolumKarakterOyuncu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktif");

                    b.Property<int>("BolumKarakterId");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.Property<bool>("Secildi");

                    b.HasKey("Id");

                    b.HasIndex("BolumKarakterId");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("OyuncuId");

                    b.ToTable("BolumKarakterOyunculari","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.EngelDurumu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("EngelDurumlari","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Firma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("Aktif");

                    b.Property<string>("EPosta")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<string>("FaceBook")
                        .HasMaxLength(200);

                    b.Property<string>("Faks")
                        .HasMaxLength(20);

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<string>("Instagram")
                        .HasMaxLength(200);

                    b.Property<string>("Linkedin")
                        .HasMaxLength(200);

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Telefon")
                        .HasMaxLength(20);

                    b.Property<string>("Twitter")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.ToTable("Firmalar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Il", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.ToTable("Iller","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Ilce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("IlId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("IlId");

                    b.ToTable("Ilceler","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Cinsiyet");

                    b.Property<DateTime>("DogumTarihi");

                    b.Property<string>("EPosta")
                        .HasMaxLength(200);

                    b.Property<string>("FaceBook")
                        .HasMaxLength(200);

                    b.Property<string>("Instagram")
                        .HasMaxLength(200);

                    b.Property<int>("KanGrubu");

                    b.Property<string>("Linkedin")
                        .HasMaxLength(200);

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TC")
                        .HasMaxLength(11);

                    b.Property<string>("Twitter")
                        .HasMaxLength(200);

                    b.Property<int>("UyrukId");

                    b.Property<string>("WebSitesi")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("UyrukId");

                    b.ToTable("Kisiler","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.KisiBanka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktif");

                    b.Property<int>("BankaId");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<string>("HesapNumarasi");

                    b.Property<string>("Iban");

                    b.Property<int>("KisiId");

                    b.Property<string>("SubeKodu");

                    b.HasKey("Id");

                    b.HasIndex("BankaId");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("KisiId");

                    b.ToTable("KisiBankalari","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kullanici", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Sifre")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Adres")
                        .HasMaxLength(100);

                    b.Property<bool>("Aktif");

                    b.Property<string>("EPosta")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<string>("Faks")
                        .HasMaxLength(100);

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("IlceId");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Telefon")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("IlceId");

                    b.ToTable("Musteriler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Oyuncu", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("AltBeden")
                        .HasMaxLength(20);

                    b.Property<string>("AnneAdiSoyadi");

                    b.Property<int>("AyakNumarasi");

                    b.Property<string>("BabaAdiSoyadi");

                    b.Property<int>("Boy");

                    b.Property<int>("EngelDurumuId");

                    b.Property<int>("GozRengi");

                    b.Property<decimal>("Kase");

                    b.Property<int>("Kilo");

                    b.Property<string>("OyuculukEgitimi")
                        .HasMaxLength(4000);

                    b.Property<int>("SacRengi");

                    b.Property<string>("Tecrubeler")
                        .HasMaxLength(4000);

                    b.Property<int>("TenRengi");

                    b.Property<string>("UstBeden")
                        .HasMaxLength(20);

                    b.Property<string>("Yetenekleri")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.HasIndex("EngelDurumuId");

                    b.ToTable("Oyuncular","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuResim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktif");

                    b.Property<string>("DosyaYolu");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("OyuncuId");

                    b.ToTable("OyuncuResimleri","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktif");

                    b.Property<string>("DosyaYolu");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("OyuncuId");

                    b.ToTable("OyuncuVideolari","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Proje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("Adi")
                        .HasMaxLength(50);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int>("GuncelleyenId");

                    b.Property<int>("IsTipi");

                    b.Property<int>("IsiTakipEdenId");

                    b.Property<string>("Konu")
                        .HasMaxLength(4000);

                    b.Property<int>("Mecra");

                    b.Property<int>("MusteriId");

                    b.Property<int>("SupervisorId");

                    b.Property<int>("YonetmenId");

                    b.HasKey("Id");

                    b.HasIndex("EkleyenId");

                    b.HasIndex("GuncelleyenId");

                    b.HasIndex("IsiTakipEdenId");

                    b.HasIndex("MusteriId");

                    b.HasIndex("SupervisorId");

                    b.HasIndex("YonetmenId");

                    b.ToTable("Projeler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Supervisor", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("Supervisorler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Uyruk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Uyruklar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Yonetmen", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

                    b.ToTable("Yonetmenler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Banka", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Bolum", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Proje", "Proje")
                        .WithMany()
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.BolumKarakter", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Bolum", "Bolum")
                        .WithMany()
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Oyuncu")
                        .WithMany("BolumKarakterleri")
                        .HasForeignKey("OyuncuId");
                });

            modelBuilder.Entity("CastAjansCore.Entity.BolumKarakterOyuncu", b =>
                {
                    b.HasOne("CastAjansCore.Entity.BolumKarakter", "BolumKarakter")
                        .WithMany()
                        .HasForeignKey("BolumKarakterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany()
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Firma", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Il", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Ilce", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Il", "Il")
                        .WithMany("Ilceler")
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kisi", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Uyruk", "Uyruk")
                        .WithMany()
                        .HasForeignKey("UyrukId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.KisiBanka", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Banka", "Banka")
                        .WithMany()
                        .HasForeignKey("BankaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("KisiId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kullanici", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Musteri", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Oyuncu", b =>
                {
                    b.HasOne("CastAjansCore.Entity.EngelDurumu", "EngelDurumu")
                        .WithMany()
                        .HasForeignKey("EngelDurumuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuResim", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany("OyuncuResimleri")
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuVideo", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany("OyuncuVideolari")
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Proje", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Ekleyen")
                        .WithMany()
                        .HasForeignKey("EkleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "Guncelleyen")
                        .WithMany()
                        .HasForeignKey("GuncelleyenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Kisi", "IsiTakipEden")
                        .WithMany()
                        .HasForeignKey("IsiTakipEdenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Supervisor", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Yonetmen", "Yonetmen")
                        .WithMany()
                        .HasForeignKey("YonetmenId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Supervisor", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Yonetmen", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
