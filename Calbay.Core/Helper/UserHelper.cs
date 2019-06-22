using System;
using System.Collections.Generic;
using System.Text;
using static Calbay.Core.Entities.Enums;

namespace Calbay.Core.Helper
{
    public class UserHelper : IUserHelper
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public string Soyadi { get; set; }

        public string KullaniciAdi { get; set; }

        public EnuRol Rol { get; set; }

        public List<MenuDto> Menuler { get; set; }

        public string Mesaj { get; set; }
    }
}
