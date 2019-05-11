using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Kullanicilar", Schema = "Sistem")]
    public class Kullanici
    {
        [Key]
        [ForeignKey("Kisi")]
        public int KisiId { get; set; }

        [MaxLength(4000)]
        public string Sifre { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
