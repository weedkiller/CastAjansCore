using Calbay.Core.Entities;
using System.Collections.Generic;

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
