using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
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
