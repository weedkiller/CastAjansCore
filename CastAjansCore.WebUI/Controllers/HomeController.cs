using CastAjansCore.Business.Abstract;
using CastAjansCore.WebUI.Filters;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize]    
    public class HomeController : Controller
    {
        IKisiServis _kisiServis;
        private readonly LoginHelper _loginHelper;
        
        public HomeController(IKisiServis kisiServis, LoginHelper loginHelper)
        {
            _kisiServis = kisiServis;
            _loginHelper = loginHelper;            
            ViewBag.UserHelper = _loginHelper.UserHelper;
        }

        [HandleException]
        public IActionResult Index()
        {
            ViewBag.UserHelper = _loginHelper.UserHelper;
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("tr-TR")),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );



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
            return View();
        }


        [Route("delete/{id?}")]
        public string Delete(int id)
        {
            return $"delete {id}";
        }
    }
}