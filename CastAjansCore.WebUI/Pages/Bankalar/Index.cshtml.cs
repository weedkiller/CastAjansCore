using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CastAjansCore.WebUI.Pages.Bankalar
{
    public class IndexModel : PageModel
    { 
        private readonly IBankaServis _BankaServis;
        
        public IndexModel(IBankaServis BankaServis)
        {
            _BankaServis = BankaServis;
        } 

        public List<Banka> bankalar = new List<Banka>();
        public void OnGet()
        {
            bankalar = _BankaServis.GetList();
        }
    }
}