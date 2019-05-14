using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CastAjansCore.Entity
{
    [Table("Supervisorler", Schema = "Cast")]
    public class Supervisor: IEntity
    {
        [Key]
        [ForeignKey("Kisi")]
        public int KisiId { get; set; }

        [MaxLength(4000)]
        public string Aciklama { get; set; }

        public virtual Kisi Kisi { get; set; }
    }
}
