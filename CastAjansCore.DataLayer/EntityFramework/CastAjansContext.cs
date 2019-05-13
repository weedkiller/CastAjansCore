using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
