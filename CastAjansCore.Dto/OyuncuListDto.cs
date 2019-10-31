using Calbay.Core.Helper;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
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
                    var age = DateTime.Today.Year - DogumTarihi.Value.Year;
                    // Go back to the year the person was born in case of a leap year
                    if (DogumTarihi.Value.Date > DateTime.Today.AddYears(-age)) age--;
                    return age;
                }

            }
        }
        public List<Proje> Projeler { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        public decimal? Kase { get; set; }

        public string ProfilFotoUrl { get; set; }

        public string Cep { get; set; }

        public int? Boy { get; set; }
        public int? Kilo { get; set; }
        public int? UstBeden { get; set; }
        public int? AltBeden { get; set; }
        public string SacRengi { get; set; }
        public string TenRengi { get; set; }
        public string GozRengi { get; set; }
        public string Uyruk { get; set; }
        public string Cinsiyet { get; set; }
    }
}
