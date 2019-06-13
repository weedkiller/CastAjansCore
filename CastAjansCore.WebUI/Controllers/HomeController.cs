using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IKisiServis _kisiServis;
        public HomeController(IKisiServis kisiServis)
        {
            _kisiServis = kisiServis;
        }
         
        public PartialViewResult _Menu()
        {
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

            return PartialView("_Menu", menuListDto);
        }

        [HandleException]
        public async Task<IActionResult> Index()
        {
            //IKisiServis _kisiServis = new KisiManager(new EfKisiDal());
            //Kisi kisi = new Kisi {
            //    Adi = "Önder",
            //    Soyadi = "çalbay",
            //    Cinsiyet= EnuCinsiyet.Bay,
            //    EPosta = "ondercalbay@hotmail.com",
            //    TC="18530489042",
            //    KanGrubu = EnuKanGrubu.BPozitif,
            //    WebSitesi = "ondercalbay.com"                
            //};

            //_kisiServis.Add(kisi);
            //Kisi kisi = _kisiServis.Get(k => k.Adi == "Önder");
            //HttpContext.Session.SetObject("kisiListDto", kisi);
            return View(await _kisiServis.GetListAsync());
        }


        [Route("delete/{id?}")]
        public string Delete(int id)
        {
            return $"delete {id}";
        }
    }
}