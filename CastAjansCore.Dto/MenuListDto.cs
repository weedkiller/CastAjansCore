using Calbay.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class MenuListDto
    {
        public MenuListDto()
        {
            Menuler = new List<MenuDto>();
        }
        public UserHelper UserHelper { get; set; }

        public List<MenuDto> Menuler  { get; set; }
    }
}
