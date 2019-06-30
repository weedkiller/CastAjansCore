using Calbay.Core.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class OyuncuListDto
    {
        public int Id { get; set; }

        [Display(Name = "Adı")]
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DogumTarihi { get; set; }

        public int? Yas
        {
            get
            {
                if (DogumTarihi == null)
                {
                    return null;
                }
                else
                {
                    return Math.Ceiling(DateTime.Today.Subtract(DogumTarihi.Value).TotalDays / 360).ToInt();
                }

            }
        }

        public string ProfilFotoUrl { get; set; }

        public int? Boy { get; set; }
        public int? Kilo { get; set; }
        public int? UstBeden { get; set; }
        public int? AltBeden { get; set; }
        public int? Kase { get; set; }
        public string SacRengi { get; set; }
        public string GozRengi { get; set; }
    }
}
