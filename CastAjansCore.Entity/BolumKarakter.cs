using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("BolumKarakterleri", Schema = "Cast")]
    public class BolumKarakter : BaseEntity
    {
        [Required]
        public int BolumId { get; set; }

        [MaxLength(50)]
        public string Adi { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        public int KarakterSayisi { get; set; }

        [ForeignKey("BolumId")]
        public virtual Bolum Bolum { get; set; }
    }
}
