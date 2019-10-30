using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class ProjeKarakterDetailDto
    {
        public int Id { get; set; }

        [Display(Name ="Karakter")]
        public string Adi { get; set; }

        [Display(Name = "Karakter Sayısı")]
        public int? KarakterSayisi { get; set; }

        public List<OyuncuDetailDto> Oyuncular { get; set; }
    }
}