using Calbay.Core.Helper;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public DateTime DogumTarihi { get; set; }

        public int Yas { get { return Math.Ceiling(DateTime.Today.Subtract(DogumTarihi).TotalDays / 360).ToInt(); } }

        public string ProfilUrl { get; set; }

    }
}
