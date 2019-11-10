using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class OyuncuFilterDto
    {
        public List<SelectListItem> Uyruklar { get; set; }

        public List<SelectListItem> Iller { get; set; }

        public string TC { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int YasMin { get; set; }
        public int YasMaks { get; set; }
        public int Cinsiyet { get; set; }
        public int Uyruk { get; set; }
        public int Il { get; set; }
        public int Ilce { get; set; }
        public int KaseMin { get; set; }
        public int KaseMaks { get; set; }
        public List<int> CastTipi { get; set; }
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
        public int SacTipi { get; set; }
        public string Ehliyet { get; set; }
        public string Genel { get; set; }
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }        
        public List<Column> Columns { get; set; }
        public List<Orders> Order { get; set; }

        public class Column
        {
            public string Name { get; set; }
            public string Data { get; set; }
        }

        public class Orders
        {
            public int column { get; set; }            
            public string dir { get; set; }
        }
    }

    
}
