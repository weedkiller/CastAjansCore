using System.ComponentModel.DataAnnotations;

namespace Calbay.Core.Entities
{
    public enum EnuRol
    {
        [Display(Name = "Admin")]
        admin = 1,

        [Display(Name = "Çalısan")]
        calisan = 2,

        [Display(Name = "Test")]
        test = 3,

    }
}
