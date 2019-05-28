using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class KisiEditDto
    {
        public KisiEditDto()
        {
            Kisi = new Kisi();
            Uyruklar = new List<SelectListItem>();
        }
        public Kisi Kisi { get; set; }

        public List<SelectListItem> Uyruklar { get; set; }
    }
}
