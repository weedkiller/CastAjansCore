using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class KullaniciEditDto
    {
        public KullaniciEditDto()
        {
            Kullanici = new Kullanici();
            Kisi = new KisiEditDto();
        }
        public Kullanici Kullanici { get; set; }

        public KisiEditDto Kisi { get; set; }
    }
}
