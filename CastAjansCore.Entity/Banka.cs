using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Bankalar", Schema = "Sistem")]
    public class Banka : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

    }
}
