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
    [Migration("20190616142439_oyuncuResimProfilUrl")]
    partial class oyuncuResimProfilUrl
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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.HasKey("Id");

                    b.ToTable("Bankalar","Sistem");
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

                    b.Property<int?>("EkleyenId");

                    b.Property<string>("FaceBook")
                        .HasMaxLength(200);

                    b.Property<string>("Faks")
                        .HasMaxLength(20);

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.HasKey("Id");

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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("IlId");

                    b.HasKey("Id");

                    b.HasIndex("IlId");

                    b.ToTable("Ilceler","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Adres")
                        .HasMaxLength(100);

                    b.Property<bool>("Aktif");

                    b.Property<string>("AnneAdiSoyadi");

                    b.Property<string>("BabaAdiSoyadi");

                    b.Property<int?>("BankaId");

                    b.Property<int>("Cinsiyet");

                    b.Property<DateTime>("DogumTarihi");

                    b.Property<string>("EPosta")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<string>("FaceBook")
                        .HasMaxLength(200);

                    b.Property<string>("Faks")
                        .HasMaxLength(13);

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<string>("HesapNumarasi")
                        .HasMaxLength(20);

                    b.Property<string>("Iban")
                        .HasMaxLength(30);

                    b.Property<int?>("IlceId");

                    b.Property<string>("Instagram")
                        .HasMaxLength(200);

                    b.Property<int>("KanGrubu");

                    b.Property<string>("KimlikArkaUrl")
                        .HasMaxLength(200);

                    b.Property<string>("KimlikOnUrl")
                        .HasMaxLength(200);

                    b.Property<string>("Linkedin")
                        .HasMaxLength(200);

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("SubeKodu")
                        .HasMaxLength(4);

                    b.Property<string>("TC")
                        .HasMaxLength(11);

                    b.Property<string>("Telefon")
                        .HasMaxLength(13);

                    b.Property<string>("Telefon2")
                        .HasMaxLength(13);

                    b.Property<string>("Twitter")
                        .HasMaxLength(200);

                    b.Property<int?>("UyrukId");

                    b.Property<string>("WebSitesi")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IlceId");

                    b.HasIndex("UyrukId");

                    b.ToTable("Kisiler","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kullanici", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Adres")
                        .HasMaxLength(100);

                    b.Property<bool>("Aktif");

                    b.Property<string>("EPosta")
                        .HasMaxLength(200);

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<string>("Faks")
                        .HasMaxLength(13);

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int?>("IlceId");

                    b.Property<string>("LogoUrl")
                        .HasMaxLength(100);

                    b.Property<string>("Telefon")
                        .HasMaxLength(13);

                    b.Property<string>("Telefon2")
                        .HasMaxLength(13);

                    b.HasKey("Id");

                    b.HasIndex("IlceId");

                    b.ToTable("Musteriler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Oyuncu", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(4000);

                    b.Property<bool>("Aktif");

                    b.Property<int?>("AltBeden");

                    b.Property<int?>("AyakNumarasi");

                    b.Property<int?>("Boy");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<string>("EngelDurumu")
                        .HasMaxLength(200);

                    b.Property<int>("GozRengi");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<decimal?>("Kase");

                    b.Property<int?>("Kilo");

                    b.Property<string>("Meslek")
                        .HasMaxLength(200);

                    b.Property<string>("OyuculukEgitimi")
                        .HasMaxLength(4000);

                    b.Property<string>("ProfilFotoUrl")
                        .HasMaxLength(100);

                    b.Property<int>("SacRengi");

                    b.Property<string>("Tecrubeler")
                        .HasMaxLength(4000);

                    b.Property<int>("TenRengi");

                    b.Property<int?>("UstBeden");

                    b.Property<string>("YabanciDil")
                        .HasMaxLength(200);

                    b.Property<string>("Yetenekleri")
                        .HasMaxLength(4000);

                    b.HasKey("Id");

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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.HasKey("Id");

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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.HasKey("Id");

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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("IsTipi");

                    b.Property<int>("IsiTakipEdenId");

                    b.Property<int>("Mecra");

                    b.Property<int>("MusteriId");

                    b.Property<DateTime>("TarihBas");

                    b.Property<DateTime>("TarihBit");

                    b.Property<string>("TeklifAciklama");

                    b.HasKey("Id");

                    b.HasIndex("IsiTakipEdenId");

                    b.HasIndex("MusteriId");

                    b.ToTable("Projeler","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.ProjeKarakter", b =>
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

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("KarakterSayisi");

                    b.Property<int?>("OyuncuId");

                    b.Property<int>("ProjeId");

                    b.HasKey("Id");

                    b.HasIndex("OyuncuId");

                    b.HasIndex("ProjeId");

                    b.ToTable("ProjeKarakterleri","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.ProjeKarakterOyuncu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.Property<int>("OyuncuId");

                    b.Property<int>("ProjeKarakterId");

                    b.Property<int>("karakterDurumu");

                    b.HasKey("Id");

                    b.HasIndex("OyuncuId");

                    b.HasIndex("ProjeKarakterId");

                    b.ToTable("ProjeKarakterOyunculari","Cast");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Uyruk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Aktif");

                    b.Property<DateTime>("EklemeZamani");

                    b.Property<int?>("EkleyenId");

                    b.Property<DateTime>("GuncellemeZamani");

                    b.Property<int?>("GuncelleyenId");

                    b.HasKey("Id");

                    b.ToTable("Uyruklar","Sistem");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Ilce", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Il", "Il")
                        .WithMany("Ilceler")
                        .HasForeignKey("IlId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Kisi", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId");

                    b.HasOne("CastAjansCore.Entity.Uyruk", "Uyruk")
                        .WithMany()
                        .HasForeignKey("UyrukId");
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
                    b.HasOne("CastAjansCore.Entity.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId");
                });

            modelBuilder.Entity("CastAjansCore.Entity.Oyuncu", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kisi", "Kisi")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuResim", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany("OyuncuResimleri")
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.OyuncuVideo", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany("OyuncuVideolari")
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.Proje", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Kullanici", "IsiTakipEden")
                        .WithMany()
                        .HasForeignKey("IsiTakipEdenId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.Musteri", "Musteri")
                        .WithMany()
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.ProjeKarakter", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Oyuncu")
                        .WithMany("ProjeKarakterleri")
                        .HasForeignKey("OyuncuId");

                    b.HasOne("CastAjansCore.Entity.Proje", "Proje")
                        .WithMany()
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CastAjansCore.Entity.ProjeKarakterOyuncu", b =>
                {
                    b.HasOne("CastAjansCore.Entity.Oyuncu", "Oyuncu")
                        .WithMany()
                        .HasForeignKey("OyuncuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CastAjansCore.Entity.ProjeKarakter", "ProjeKarakter")
                        .WithMany()
                        .HasForeignKey("ProjeKarakterId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
