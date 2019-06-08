using Calbay.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Projeler", Schema = "Cast")]
    public class Proje : BaseEntity, IEntity
    {
        [Required]
        [Display(Name = "Müşteri")]
        public int MusteriId { get; set; }

        [Display(Name ="Başlama Tarihi")]
        public DateTime TarihBas { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime TarihBit { get; set; }

        [MaxLength(50)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Display(Name = "İş Tipi")]
        public EnuIsTipi IsTipi { get; set; }

        [Display(Name = "Mecra")]
        public EnuMecra Mecra { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Acıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "İşi Takip Eden")]
        public int IsiTakipEdenId { get; set; }

        [Display(Name = "Teklif Açıklama")]
        public string TeklifAciklama { get; set; }
        
        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }

        [ForeignKey("IsiTakipEdenId")]
        public virtual Kisi IsiTakipEden { get; set; }
    }
}
