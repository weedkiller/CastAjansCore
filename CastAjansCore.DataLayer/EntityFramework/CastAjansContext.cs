using CastAjansCore.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CastAjansCore.DataLayer.EntityFramework
{
    public class CastAjansContext : DbContext
    {
        public DbSet<Banka> Bankalar { get; set; }

        public DbSet<Bolum> Bolumler { get; set; }

        public DbSet<BolumKarakter> BolumKarakterleri { get; set; }

        public DbSet<BolumKarakterOyuncu> BolumKarakterOyunculari { get; set; }

        public DbSet<EngelDurumu> EngelDurumlari { get; set; }

        public DbSet<Firma> Firma { get; set; }

        public DbSet<Il> Iller { get; set; }

        public DbSet<Ilce> Ilceler { get; set; }

        public DbSet<Kisi> Kisiler { get; set; }

        public DbSet<KisiBanka> KisiBankalar { get; set; }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }

        public DbSet<Oyuncu> Oyuncular { get; set; }

        public DbSet<OyuncuResim> OyuncuResimleri { get; set; }

        public DbSet<OyuncuVideo> OyuncuVideolari { get; set; }

        public DbSet<Proje> Projeler { get; set; }

        public DbSet<Supervisor> Supervisorler { get; set; }

        public DbSet<Uyruk> Uyruklar { get; set; }

        public DbSet<Yonetmen> Yonetmenler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
