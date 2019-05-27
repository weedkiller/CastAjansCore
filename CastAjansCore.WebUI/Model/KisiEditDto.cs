using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class KisiEditDto
    {
        public Kisi Kisi { get; set; }

        public List<SelectListItem> Uyruklar { get; set; }
    }
}
