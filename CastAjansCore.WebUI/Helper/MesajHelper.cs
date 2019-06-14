using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CastAjansCore.WebUI.Helper
{
    public class MesajHelper
    {
        public static void MesajEkle(dynamic viewBag, string mesaj)
        {
            List<string> mesajlar = viewBag.Mesajlar == null ? new List<string>() : viewBag.Mesajlar;
            mesajlar.Add(mesaj);
            viewBag.Mesajlar = mesajlar;
        }

        public static void HataEkle(dynamic viewBag, string mesaj)
        {
            List<string> mesajlar = viewBag.Hatalar == null ? new List<string>() : viewBag.Hatalar;
            mesajlar.Add(mesaj);
            viewBag.Hatalar = mesajlar;
        }

        internal static void HataEkle(dynamic viewBag, ModelStateDictionary modelState)
        {
            foreach (var item in modelState.Select(i => i.Value.Errors).Where(i => i.Count > 0).ToList())
            {
                foreach (var err in item)
                {
                    HataEkle(viewBag, err.ErrorMessage);
                }
                
            }
        }
    }
}
