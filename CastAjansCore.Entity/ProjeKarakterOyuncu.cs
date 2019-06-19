using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("ProjeKarakterOyunculari", Schema = "Cast")]
    public class ProjeKarakterOyuncu : BaseEntity, IEntity
    {
        [Required]
        public int ProjeKarakterId { get; set; }

        [Required]
        public int OyuncuId { get; set; }

        public EnuKarakterDurumu  KarakterDurumu { get; set; }

        [ForeignKey("ProjeKarakterId")]
        public virtual ProjeKarakter ProjeKarakter { get; set; }

        [ForeignKey("OyuncuId")]
        public virtual Oyuncu Oyuncu { get; set; }

    }
}
