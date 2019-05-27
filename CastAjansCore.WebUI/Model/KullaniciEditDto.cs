using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class KullaniciEditDto
    {
        public Kullanici Kullanici { get; set; }

        public List<Uyruk> Uyruklar { get; set; }
    }
}
