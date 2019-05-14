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
        public string Adi { get; set; }

        [MaxLength(100)]
        public string LogoUrl { get; set; }

        [MaxLength(100)]
        public string Telefon { get; set; }
        [MaxLength(100)]
        public string Faks { get; set; }

        [MaxLength(200)]
        public string EPosta { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }

        public int IlceId { get; set; }

        public virtual Ilce Ilce { get; set; }
    }
}
