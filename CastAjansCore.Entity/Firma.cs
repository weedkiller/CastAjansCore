using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Firmalar", Schema = "Sistem")]
    public class Firma : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

        [MaxLength(100)]
        public string LogoUrl { get; set; }

        [MaxLength(20)]
        public string Telefon { get; set; }
        [MaxLength(20)]
        public string Faks { get; set; }

        [MaxLength(200)]
        public string EPosta { get; set; }

        [MaxLength(200)]
        public string FaceBook { get; set; }

        [MaxLength(200)]
        public string Twitter { get; set; }

        [MaxLength(200)]
        public string Instagram { get; set; }

        [MaxLength(200)]
        public string Linkedin { get; set; }

    }
}
