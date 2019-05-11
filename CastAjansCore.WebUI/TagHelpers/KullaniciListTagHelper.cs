using CastAjansCore.Dto;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastAjansCore.WebUI.TagHelpers
{
    [HtmlTargetElement("kullanici-List")]
    public class KullaniciListTagHelper : TagHelper
    {

        private List<KisiListDto> _kisiList;

        public KullaniciListTagHelper()
        {
            _kisiList = new List<KisiListDto>
            {
                new KisiListDto{ id=1, adi="Önder", soyadi  = "Çalbay" },
                new KisiListDto { id=1, adi="Mehtap", soyadi  = "Çalbay" },
                new KisiListDto{ id=1, adi="Özgün", soyadi  = "Çalbay" }
            };
        }

        [HtmlAttributeName("count")]
        public int _count { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder sb = new StringBuilder();
            foreach (var item in _kisiList.Take(_count))
            {
                sb.AppendFormat("<h5><a href='/Home/Edit/{0}'>{1} {2}</a></h5>", item.id, item.adi, item.soyadi);
            }

            output.Content.SetHtmlContent(sb.ToString());

            base.Process(context, output);
        }
    }
}