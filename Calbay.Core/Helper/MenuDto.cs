using System.Collections.Generic;

namespace Calbay.Core.Helper
{
    public class MenuDto
    {
        public MenuDto()
        {
            AltMenuler = new List<MenuDto>();

        }
        public string Adi { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public List<MenuDto> AltMenuler { get; set; }
    }
}