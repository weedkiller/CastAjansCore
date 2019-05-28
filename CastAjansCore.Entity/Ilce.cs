using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Ilceler", Schema = "Sistem")]
    public class Ilce : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(200)]
        [Display(Name = "İlçe")]
        public string Adi { get; set; }

        public int IlId { get; set; }

        [ForeignKey("IlId")]
        public virtual Il Il { get; set; }
    }
}
