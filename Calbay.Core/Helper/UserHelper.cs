using System;
using System.Collections.Generic;
using System.Text;

namespace Calbay.Core.Helper
{
    public class UserHelper : IUserHelper
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string KullaniciAdi { get; set; }

        public string Rol { get; set; }
    }
}
