using Calbay.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Oyuncular", Schema = "Cast")]
    public class Oyuncu: IEntity
    {
        [Key]
        [ForeignKey("Kisi")]
        public int Id { get; set; }

        public string AnneAdiSoyadi { get; set; }

        public string BabaAdiSoyadi { get; set; }

        public int Boy { get; set; }

        public int Kilo { get; set; }

        [MaxLength(20)]
        public string AltBeden { get; set; }

        [MaxLength(20)]
        public string UstBeden { get; set; }

        public int AyakNumarasi { get; set; }

        public EnuGozRengi GozRengi { get; set; }

        public EnuTenRengi TenRengi { get; set; }

        public EnuSacRengi SacRengi { get; set; }

        [MaxLength(200)]
        public string EngelDurumu { get; set; }

        [MaxLength(4000)]
        public string OyuculukEgitimi { get; set; }

        [MaxLength(4000)]
        public string Tecrubeler { get; set; }

        [MaxLength(4000)]
        public string Yetenekleri { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        public decimal Kase { get; set; }
        
        public virtual Kisi Kisi { get; set; }

        public ICollection<OyuncuResim> OyuncuResimleri { get; set; }

        public ICollection<OyuncuVideo> OyuncuVideolari { get; set; }

        public ICollection<BolumKarakter> BolumKarakterleri { get; set; }
    }
}
