using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Calbay.Core.Entities;

namespace CastAjansCore.Entity
{
    [Table("Uyruklar", Schema = "Sistem")]
    public class Uyruk: IEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }
    }
}
