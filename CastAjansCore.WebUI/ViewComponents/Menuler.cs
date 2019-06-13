using CastAjansCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.ViewComponents
{
    public class Menuler : ViewComponent
    {
        public Menuler()
        {

        }
 
        public IViewComponentResult Invoke()
        {
            //parametre alıp almadığını kontrol ediyorum    
            var menuListDto = new MenuListDto
            {
                //UserHelper = HttpContext.Session.GetUserHelper(),
                Menuler = new List<MenuDto>
                {
                    new MenuDto { Adi = "Müşteriler", Icon = "icon-clapboard-play", Link = "/Musteriler" } ,
                    new MenuDto { Adi = "Oyuncular", Icon = "icon-accessibility", Link = "/Oyuncular" },
                    new MenuDto { Adi = "Oyuncular", Icon = "icon-accessibility", Link = "/Oyuncular" },
                    new MenuDto
                    {
                        Adi = "Sistem",
                        Icon = "icon-gear",
                        Link = "#",
                        AltMenuler = new List<MenuDto> {
                             new MenuDto { Adi = "Bankalar", Link = "/Bankalar" } ,
                             new MenuDto{ Adi="Firmalar", Link="/Firmalar" }
                        }
                    }
                }
            };

            return View();
        }
    }
}
