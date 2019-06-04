using Calbay.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Iller", Schema = "Sistem")]
    public class Il :  IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "İl")]
        public string Adi { get; set; }

        public ICollection<Ilce> Ilceler { get; set; }
    }
}
