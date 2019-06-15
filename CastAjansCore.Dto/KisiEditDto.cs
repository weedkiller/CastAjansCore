using CastAjansCore.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CastAjansCore.Dto
{
    public class KisiEditDto
    {
        public KisiEditDto()
        {
            Kisi = new Kisi();
            Uyruklar = new List<SelectListItem>();
            Iller = new List<SelectListItem>();
            Ilceler = new List<SelectListItem>();
            Bankalar = new List<SelectListItem>();
        }

        public IFormFile KimlikOnFile { get; set; }

        public IFormFile KimlikArkaFile { get; set; }

        public Kisi Kisi { get; set; }

        public List<SelectListItem> Uyruklar { get; set; }

        public List<SelectListItem> Iller { get; set; }

        public List<SelectListItem> Ilceler { get; set; }

        public List<SelectListItem> Bankalar { get; set; }
    }
}
