using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Projeler", Schema = "Cast")]
    public class Proje : BaseEntity, IEntity
    {
        [Required]
        public int MusteriId { get; set; }

        [MaxLength(50)]
        public string Adi { get; set; }

        public EnuIsTipi IsTipi { get; set; }

        public EnuMecra Mecra { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        [MaxLength(4000)]
        public string Konu { get; set; }

        public int SupervisorId { get; set; }

        public int IsiTakipEdenId { get; set; }

        public int YonetmenId { get; set; }

        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }

        [ForeignKey("YonetmenId")]
        public virtual Yonetmen Yonetmen { get; set; }

        [ForeignKey("SupervisorId")]
        public virtual Supervisor Supervisor { get; set; }

        [ForeignKey("IsiTakipEdenId")]
        public virtual Kisi IsiTakipEden { get; set; }
    }
}
