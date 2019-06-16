using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastAjansCore.Entity
{
    [Table("OyuncuResimleri", Schema = "Cast")]
    public class OyuncuResim : BaseEntity, IEntity
    {
        public int OyuncuId { get; set; }

        public string DosyaYolu { get; set; }

        [ForeignKey("OyuncuId")]
        public virtual Oyuncu Oyuncu { get; set; }
    }
}
