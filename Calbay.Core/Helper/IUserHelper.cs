using static Calbay.Core.Entities.Enums;

namespace Calbay.Core.Helper
{
    interface IUserHelper
    {
        int Id { get; set; }

        string Adi { get; set; }

        string Soyadi { get; set; }

        string KullaniciAdi { get; set; }

        EnuRol Rol { get; set; }
    }
}
