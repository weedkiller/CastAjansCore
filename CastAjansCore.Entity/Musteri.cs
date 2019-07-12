using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Musteriler", Schema = "Cast")]
    public class Musteri : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [MaxLength(100)]
        [Display(Name = "Logo")]
        public string LogoUrl { get; set; }

        [MaxLength(14)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon 1")]
        public string Telefon { get; set; }
        [MaxLength(14)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon 2")]
        public string Telefon2 { get; set; }

        [MaxLength(14)]
        [DataType(DataType.PhoneNumber)]
        public string Faks { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [MaxLength(200)]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }

        [Display(Name = "İlçe")]
        public int? IlceId { get; set; }

        [ForeignKey("IlceId")]
        public virtual Ilce Ilce { get; set; }


    }
}
