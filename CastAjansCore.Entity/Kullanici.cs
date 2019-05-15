using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Kullanicilar", Schema = "Sistem")]
    public class Kullanici: IEntity
    {
        [Key]
        [ForeignKey("Kisi")]
        public int Id { get; set; }

        [MaxLength(4000)]
        public string Sifre { get; set; }

        public virtual Kisi Kisi { get; set; }
        
    }
}
