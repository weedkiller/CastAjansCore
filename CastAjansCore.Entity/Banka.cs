using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Bankalar", Schema = "Sistem")]
    public class Banka : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Adi { get; set; }

    }
}
