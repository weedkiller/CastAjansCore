using Calbay.Core.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI
{
    public static class SessionExtentionMethots
    {
        public static UserHelper GetUserHelper(this ISession session)
        {
            var u = session.GetObject<UserHelper>("UserHelper");
            if (u == null)
            {
                u = new UserHelper
                {
                    Id = 0,
                    Adi = "boş",
                    Soyadi = "boş",
                    KullaniciAdi = "boş",
                    //Menuler = new List<MenuDto>
                    //{
                    //    new MenuDto { Adi = "Müşteriler", Icon = "icon-clapboard-play", Link = "/Musteriler" } ,
                    //    new MenuDto { Adi = "Oyuncular", Icon = "icon-accessibility", Link = "/Oyuncular" },
                    //    new MenuDto
                    //    {
                    //        Adi = "Sistem",
                    //        Icon = "icon-gear",
                    //        Link = "#",
                    //        AltMenuler = new List<MenuDto> {
                    //             new MenuDto { Adi = "Bankalar", Link = "/Bankalar" } ,
                    //             new MenuDto{ Adi="Firmalar", Link="/Firmalar" },
                    //             new MenuDto { Adi = "İller", Link = "/Iller" } ,
                    //             new MenuDto{ Adi="Kullanıcılar", Link="/Kullanicilar" },
                    //             new MenuDto{ Adi="Uyruklar", Link="/Uyruklar" }
                    //        }
                    //    }
                    //}
                };
                session.SetUserHelper(u);
            }
            return u;
        }

        public static void SetUserHelper(this ISession session, UserHelper userHelper)
        {
            session.SetObject("UserHelper", userHelper);
        }

        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string val = session.GetString(key);
            if (string.IsNullOrEmpty(val))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(val);
            }
        }
    }
}
