using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class OyuncuFilterDto
    {
        public List<SelectListItem> Uyruklar { get; set; }
        public string TC { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int YasMin { get; set; }
        public int YasMaks { get; set; }
        public int Cinsiyet { get; set; }
        public int Uyruk { get; set; }
        public int KaseMin { get; set; }
        public int KaseMaks { get; set; }
        public int BoyMin { get; set; }
        public int BoyMaks { get; set; }
        public int KiloMin { get; set; }
        public int KiloMaks { get; set; }
        public int AltBedenMin { get; set; }
        public int AltBedenMaks { get; set; }
        public int UstBedenMin { get; set; }
        public int UstBedenMaks { get; set; }
        public int AyakNumarasiMin { get; set; }
        public int AyakNumarasiMaks { get; set; }
        public int GozRengi { get; set; }
        public int TenRengi { get; set; }
        public int SacRengi { get; set; }
        
    }
}
