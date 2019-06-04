using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
        public Kisi Kisi { get; set; }

        public List<SelectListItem> Uyruklar { get; set; }

        public List<SelectListItem> Iller { get; set; }

        public List<SelectListItem> Ilceler { get; set; }
    }
}
