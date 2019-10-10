using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Linq;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class CastAjansContext : DbContext
    {
        //private readonly ConnectionStrings _connectionStrings;

        //public CastAjansContext(IOptions<ConnectionStrings> connectionStrings)
        //{
        //    _connectionStrings = connectionStrings.Value;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json",true,true)
                                .Build();

            string cnnStr = builder.GetConnectionString("DefaultConnection");

            //optionsBuilder.UseSqlServer(_connectionStrings.DefaultConnection);
            //string cnnStr = "Data Source=94.73.146.4;Initial Catalog=u7506792_CastAja;Persist Security Info=True;User ID=u7506792_CastAja;Password=albay69sFENDER;MultipleActiveResultSets=True;";
            optionsBuilder.UseSqlServer(cnnStr);
        }

        public DbSet<Banka> Bankalar { get; set; }

        public DbSet<Firma> Firma { get; set; }

        public DbSet<Il> Iller { get; set; }

        public DbSet<Ilce> Ilceler { get; set; }

        public DbSet<Kisi> Kisiler { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Oyuncu> Oyuncular { get; set; }

        public DbSet<OyuncuResim> OyuncuResimleri { get; set; }

        public DbSet<OyuncuVideo> OyuncuVideolari { get; set; }

        public DbSet<Proje> Projeler { get; set; }

        public DbSet<ProjeKarakter> ProjeKarakterleri { get; set; }

        public DbSet<ProjeKarakterOyuncu> ProjeKarakterOyunculari { get; set; }

        public DbSet<Uyruk> Uyruklar { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kisi>().HasData(
                new Kisi
                {
                    Id = 1,
                    Adi = "Admin",
                    Soyadi = "Soyadi",
                    EkleyenId = 1,
                    EklemeZamani = DateTime.Today,
                    GuncelleyenId = 1,
                    GuncellemeZamani = DateTime.Today,
                    Aktif = true
                });

            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici
                {
                    Id = 1,
                    KullaniciAdi = "admin",
                    Sifre = "admin",
                    Rol = Calbay.Core.Entities.EnuRol.admin,
                    EkleyenId = 1,
                    EklemeZamani = DateTime.Today,
                    GuncelleyenId = 1,
                    GuncellemeZamani = DateTime.Today,
                    Aktif = true
                });

            modelBuilder.Entity<Uyruk>().HasData(
                new Uyruk
                {
                    Id = 1,
                    Adi = "TC",
                    EkleyenId = 1,
                    EklemeZamani = DateTime.Today,
                    GuncelleyenId = 1,
                    GuncellemeZamani = DateTime.Today,
                    Aktif = true
                });

            modelBuilder.Entity<Uyruk>().HasData(
                new Uyruk
                {
                    Id = 2,
                    Adi = "Diğer",
                    EkleyenId = 1,
                    EklemeZamani = DateTime.Today,
                    GuncelleyenId = 1,
                    GuncellemeZamani = DateTime.Today,
                    Aktif = true
                });

            // equivalent of modelBuilder.Conventions.AddFromAssembly(Assembly.GetExecutingAssembly());
            // look at this answer: https://stackoverflow.com/a/43075152/3419825

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
