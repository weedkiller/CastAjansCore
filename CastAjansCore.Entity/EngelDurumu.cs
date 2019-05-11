using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("EngelDurumlari", Schema = "Cast")]
    public class EngelDurumu
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adi { get; set; }
    }
}
