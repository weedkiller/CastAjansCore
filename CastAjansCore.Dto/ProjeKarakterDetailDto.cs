using System.Collections.Generic;

namespace CastAjansCore.Dto
{
    public class ProjeKarakterDetailDto
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public int KarakterSayisi { get; set; }

        public List<OyuncuDetailDto> Oyuncular { get; set; }

    }
}