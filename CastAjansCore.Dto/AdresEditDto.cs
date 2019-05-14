using Calbay.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class AdresEditDto : IEntity
    {
        public int Id { get; set; }

        public int KisiId { get; set; }

        public bool Default { get; set; }

        [MaxLength(50)]
        public string Tanim { get; set; }

        public int IlceId { get; set; }

        public string Adress { get; set; }
    }
}
