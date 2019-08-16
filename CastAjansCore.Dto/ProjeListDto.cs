using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.Dto
{
    public class ProjeListDto
    {
        public Musteri Musteri { get; set; }

        public List<Proje> Projeler { get; set; }
    }
}
