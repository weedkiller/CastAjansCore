using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Dto;
using CastAjansCore.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IKisiServis _kisiServis;
        public HomeController(IKisiServis kisiServis)
        {
            _kisiServis = kisiServis;
        }
        [HandleException]
        public IActionResult Index()
        {
            Kisi kisi = new Kisi {
                Adi = "Önder",
                Soyadi = "çalbay",
                Cinsiyet= EnuCinsiyet.Bay,
                EPosta = "ondercalbay@hotmail.com",
                TC="18530489042",
                KanGrubu = EnuKanGrubu.BPozitif,
                WebSitesi = "ondercalbay.com"                
            };

            _kisiServis.Add(kisi);

            //HttpContext.Session.SetObject("kisiListDto", kisi);
            return View(_kisiServis.GetList());
        }

        [Route("delete/{id?}")]
        public string Delete(int id)
        {
            return $"delete {id}";
        }
    }
}