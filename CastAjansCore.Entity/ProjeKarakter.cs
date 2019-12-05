using Calbay.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("ProjeKarakterleri", Schema = "Cast")]
    public class ProjeKarakter : BaseEntity, IEntity
    {
        [Required]
        public int ProjeId { get; set; }

        [MaxLength(50)]
        public string Adi { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        public int? KarakterSayisi { get; set; }

        [ForeignKey("ProjeId")] 
        public virtual Proje Proje { get; set; }

        public IList<ProjeKarakterOyuncu> ProjeKarakterOyunculari { get; set; }
    }
}
