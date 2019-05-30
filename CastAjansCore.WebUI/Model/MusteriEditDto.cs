using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class MusteriEditDto
    {
        public MusteriEditDto()
        {
            Musteri = new Musteri();
            Iller = new List<SelectListItem>();
            Ilceler = new List<SelectListItem>();
        }
        public Musteri Musteri { get; set; }

        public List<SelectListItem> Iller { get; set; }

        public List<SelectListItem> Ilceler { get; set; }
    }
}
