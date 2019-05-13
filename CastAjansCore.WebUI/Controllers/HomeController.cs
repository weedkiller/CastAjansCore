using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Dto;
using CastAjansCore.WebUI.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CastAjansCore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        [HandleException]
        public IActionResult Index()
        {
            KisiListDto kisiListDto = new KisiListDto { id = 1, adi = "Önder", soyadi = "çalbay" };
            HttpContext.Session.SetObject("kisiListDto", kisiListDto);
            return View();
        }

        [Route("delete/{id?}")]
        public string Delete(int id)
        {
            return $"delete {id}";
        }
    }
}