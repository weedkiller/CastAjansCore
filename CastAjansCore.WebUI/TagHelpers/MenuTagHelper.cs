using CastAjansCore.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.TagHelpers
{
    [HtmlTargetElement("menu-list")]
    public class MenuTagHelper : TagHelper
    {
        private List<MenuListDto> _menuList;

        public MenuTagHelper()
        {
            var menuListDto = new MenuListDto
            {
                //UserHelper = HttpContext.Session.GetUserHelper(),
                Menuler = new List<MenuDto>
                {
                    new MenuDto { Adi = "Müşteriler", Icon = "icon-clapboard-play", Link = "/Musteriler" } ,
                    new MenuDto { Adi = "Oyuncular", Icon = "icon-accessibility", Link = "/Oyuncular" },
                    new MenuDto { Adi = "Oyuncular", Icon = "icon-accessibility", Link = "/Oyuncular" },
                    new MenuDto
                    {
                        Adi = "Sistem",
                        Icon = "icon-gear",
                        Link = "#",
                        AltMenuler = new List<MenuDto> {
                             new MenuDto { Adi = "Bankalar", Link = "/Bankalar" } ,
                             new MenuDto{ Adi="Firmalar", Link="/Firmalar" }
                        }
                    }
                }
            };
        }

        [HtmlAttributeName("count")]
        public int _count { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder sb = new StringBuilder();
            foreach (var item in _menuList.Take(_count))
            {
                sb.AppendFormat("<h5><a href='/Home/Edit/{0}'>{1} {2}</a></h5>", item.Menuler, item.Menuler, item.Menuler);
            }

            output.Content.SetHtmlContent(sb.ToString());

            base.Process(context, output);
        }
    }
}
