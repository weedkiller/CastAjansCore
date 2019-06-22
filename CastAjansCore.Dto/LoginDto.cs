using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class LoginDto
    {
        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}
