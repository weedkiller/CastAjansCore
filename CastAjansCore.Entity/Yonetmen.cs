using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Yonetmenler", Schema = "Cast")]
    public class Yonetmen
    {
        [Key]
        [ForeignKey("Kisi")]
        public int Id { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
