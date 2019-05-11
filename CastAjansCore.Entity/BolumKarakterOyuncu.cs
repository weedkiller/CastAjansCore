using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastAjansCore.Entity
{
    [Table("BolumKarakterOyunculari", Schema = "Cast")]
    public class BolumKarakterOyuncu : BaseEntity
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
