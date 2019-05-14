using Calbay.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Iller", Schema = "Sistem")]
    public class Il : BaseEntity, IEntity
    {
        [Required]
        [MaxLength(200)]
        public string Adi { get; set; }

        public ICollection<Ilce> Ilceler { get; set; }
    }
}
