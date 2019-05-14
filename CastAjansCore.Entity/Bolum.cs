using Calbay.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Bolumler", Schema = "Cast")]
    public class Bolum : BaseEntity, IEntity
    {
        [Required]
        public int ProjeId { get; set; }

        [MaxLength(50)]
        public string Adi { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        [MaxLength(4000)]
        public string Konu { get; set; }

        public DateTime TarihBas { get; set; }

        public DateTime TarihBit { get; set; }

        [ForeignKey("ProjeId")]
        public virtual Proje Proje { get; set; }
    }
}