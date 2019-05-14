using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("BolumKarakterOyunculari", Schema = "Cast")]
    public class BolumKarakterOyuncu : BaseEntity, IEntity
    {
        [Required]
        public int BolumKarakterId { get; set; }

        [Required]
        public int OyuncuId { get; set; }

        public bool Secildi { get; set; }

        [ForeignKey("BolumKarakterId")]
        public virtual BolumKarakter BolumKarakter { get; set; }

        [ForeignKey("OyuncuId")]
        public virtual Oyuncu Oyuncu { get; set; }


    }
}
