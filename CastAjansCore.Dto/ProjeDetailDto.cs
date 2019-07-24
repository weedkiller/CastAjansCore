using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ProjeDetailDto
    {
        public int Id { get; set; }

        public string IlgiliKisi { get; set; }

        public string IlgiliTelefon { get; set; }

        public string IlgiliEPosta { get; set; }

        public string ProjeAdi { get; set; }

        public DateTime ProjeTarihBas { get; set; }

        public DateTime ProjeTarihBit { get; set; }

        public List<ProjeKarakterDetailDto> ProjeKarakterleri { get; set; }
       
    }
     
}
