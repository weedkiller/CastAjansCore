using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
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