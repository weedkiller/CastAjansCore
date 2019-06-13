using Calbay.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
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
