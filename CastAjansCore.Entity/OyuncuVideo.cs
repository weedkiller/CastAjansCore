using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("OyuncuVideolari", Schema = "Cast")]
    public class OyuncuVideo : BaseEntity, IEntity
    {
        public int OyuncuId { get; set; }

        public string DosyaYolu { get; set; }

        [ForeignKey("OyuncuId")]
        public virtual Oyuncu Oyuncu { get; set; }
    }
}
