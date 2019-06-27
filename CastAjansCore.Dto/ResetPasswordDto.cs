using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ResetPasswordDto
    {
        [Required]
        [Display(Name = "Şifre Kontrol")]
        public string Sifre { get; set; }

        [Required]
        [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor, Lütfen tekrar giriniz!")]
        [Display(Name = "Şifre Kontrol")]
        public string SifreKontrol { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
