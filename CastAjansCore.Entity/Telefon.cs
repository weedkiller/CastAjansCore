using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CastAjansCore.Entity
{
    public class Telefon : BaseEntity, IEntity
    {
        [ForeignKey("Kisi")]
        public int KisiId { get; set; }

        public bool Default { get; set; }

        public EnuTelefonTuru TelefonTuru { get; set; }

        [MaxLength(20)]
        public string Numara { get; set; }

        [MaxLength(50)]
        public string Aciklama { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
