using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    public class Adres : BaseEntity, IEntity
    {
        [ForeignKey("Kisi")]
        public int KisiId { get; set; }

        public bool Default { get; set; }

        [MaxLength(50)]
        public string Tanim { get; set; }

        public int IlceId { get; set; }

        public string Adress { get; set; }

        [ForeignKey("IlceId")]
        public virtual Ilce Ilce { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
