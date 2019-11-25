using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ProjeDetailDto
    {
        public int Id { get; set; }

        public Guid GuidId { get; set; }

        [Display(Name ="İlgili Kişi")]
        public string IlgiliKisi { get; set; }

        [Display(Name = "İlgili GSM")]
        public string IlgiliCep { get; set; }

        [Display(Name = "İlgili Telefon")]
        public string IlgiliTelefon { get; set; }

        [Display(Name = "İlgili EPosta")]        
        public string IlgiliEPosta { get; set; }

        [Display(Name = "Müşteri")]
        public string MusteriAdi { get; set; }

        [Display(Name = "Proje Adı")]
        public string ProjeAdi { get; set; }

        [Display(Name = "Proje Tarihi Baş.")]
        public DateTime ProjeTarihBas { get; set; }

        [Display(Name = "Proje Tarihi Bit.")]
        public DateTime ProjeTarihBit { get; set; }

        public string EPostaAdresleri { get; set; }

        public List<ProjeKarakterDetailDto> ProjeKarakterleri { get; set; }
       
    }
     
}
