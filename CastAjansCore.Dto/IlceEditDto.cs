using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class IlceEditDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Adi { get; set; }

        public virtual IlEditDto Il { get; set; }
    }
}
