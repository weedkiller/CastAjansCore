using Calbay.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Oyuncular", Schema = "Cast")]
    public class Oyuncu : BaseEntity, IEntity
    {
        public Oyuncu()
        {
            OyuncuResimleri = new List<OyuncuResim>();
            OyuncuVideolari = new List<OyuncuVideo>();
        }

        [Key]
        [ForeignKey("Kisi")]        
        public override int Id { get; set; }

        [Display(Name = "Cast Tipi")]
        public EnuCastTipi? CastTipi { get; set; }

        [Display(Name = "Yardımcı Oyuncu")]
        public bool? CT_YardımciOyuncu { get; set; }

        [Display(Name = "Ön FGR")]
        public bool? CT_OnFGR { get; set; }

        [Display(Name = "Ana Cast")]
        public bool? CT_AnaCast { get; set; }

        [Display(Name = "Boy(Cm)")]
        public int? Boy { get; set; }

        [Display(Name = "Kilo(Kg)")]
        public int? Kilo { get; set; }

        [Display(Name = "Alt Beden")]
        public int? AltBeden { get; set; }

        [Display(Name = "Üst Beden")]
        public int? UstBeden { get; set; }

        [Display(Name = "Ayak Numarası")]
        public int? AyakNumarasi { get; set; }

        [Display(Name = "Göz Rengi")]
        public EnuGozRengi? GozRengi { get; set; }

        [Display(Name = "Ten Rengi")]
        public EnuTenRengi? TenRengi { get; set; }

        [Display(Name = "Saç Rengi")]
        public EnuSacRengi? SacRengi { get; set; }

        [Display(Name = "Saç Tipi")]
        public EnuSacTipi? SacTipi { get; set; }

        [MaxLength(200)]
        [Display(Name = "Meslek")]
        public string Meslek { get; set; }

        [MaxLength(200)]
        [Display(Name = "Yabancı Dil")]
        public string YabanciDil { get; set; }

        [MaxLength(200)]
        [Display(Name = "Engel Durumu")]
        [DataType( DataType.MultilineText)]
        public string EngelDurumu { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Oyunculuk Eğitimi")]
        public string OyuculukEgitimi { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Tecrübeler")]
        public string Tecrubeler { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Yetenekler")]
        public string Yetenekleri { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Kaşe")]
        public decimal? Kase { get; set; }

        [MaxLength(200)]
        [Display(Name = "SSK Durumu")]
        public string SskDurumu { get; set; }

        [MaxLength(200)]
        [Display(Name = "Ehliyet")]
        public string Ehliyet { get; set; }

        public EnuOyuncuDurumu Durumu { get; set; }

        [ForeignKey("Id")]
        public virtual Kisi Kisi { get; set; }

        public List<OyuncuResim> OyuncuResimleri { get; set; }

        public List<OyuncuVideo> OyuncuVideolari { get; set; }

        public List<ProjeKarakter> ProjeKarakterleri { get; set; }
    }
}