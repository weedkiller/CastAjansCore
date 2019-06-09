using System;
using System.Collections.Generic;
using System.Text;

namespace Calbay.Core.Helper
{
    interface IUserHelper
    {
        int Id { get; set; }

        string Adi { get; set; }

        string Soyadi { get; set; }

        string KullaniciAdi { get; set; }

        string Rol { get; set; }
    }
}
