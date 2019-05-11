using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    public class Adres : BaseEntity
    {
        [ForeignKey("Kisi")]
        public int KisiId { get; set; }

        public bool Default { get; set; }

        public string Tanim { get; set; }

        public int IlceId { get; set; }

        public string Adress { get; set; }

        [ForeignKey("IlceId")]
        public virtual Ilce Ilce { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
