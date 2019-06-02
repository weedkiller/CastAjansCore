using Calbay.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Oyuncular", Schema = "Cast")]
    public class Oyuncu : IEntity
    {
        [Key]
        [ForeignKey("Kisi")]
        public int Id { get; set; }

        [Display(Name = "Anne Ad Soyad")]
        public string AnneAdiSoyadi { get; set; }

        [Display(Name = "Baba Ad Soyad")]
        public string BabaAdiSoyadi { get; set; }

        public int? Boy { get; set; }

        public int? Kilo { get; set; }

        [MaxLength(20)]
        [Display(Name = "Alt Beden")]
        public int? AltBeden { get; set; }

        [MaxLength(20)]
        [Display(Name = "Üst Beden")]
        public int? UstBeden { get; set; }

        [Display(Name = "Ayak Numarası")]
        public int? AyakNumarasi { get; set; }

        [Display(Name = "Göz Rengi")]
        public EnuGozRengi GozRengi { get; set; }

        [Display(Name = "Ten Rengi")]
        public EnuTenRengi TenRengi { get; set; }

        [Display(Name = "Saç Rengi")]
        public EnuSacRengi SacRengi { get; set; }

        [MaxLength(200)]
        [Display(Name = "Engel Durumu")]
        public string EngelDurumu { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Oyunculuk Eğitimi")]
        public string OyuculukEgitimi { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Tecrübeler")]
        public string Tecrubeler { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Yetenekler")]
        public string Yetenekleri { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Kaşe")]
        public decimal? Kase { get; set; }

        [ForeignKey("Id")]
        public virtual Kisi Kisi { get; set; }

        public ICollection<OyuncuResim> OyuncuResimleri { get; set; }

        public ICollection<OyuncuVideo> OyuncuVideolari { get; set; }

        public ICollection<ProjeKarakter> BolumKarakterleri { get; set; }
    }
}
