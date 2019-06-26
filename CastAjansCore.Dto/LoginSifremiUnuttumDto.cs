using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class LoginSifremiUnuttumDto
    {
        [MaxLength(200)]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }
    }
}
