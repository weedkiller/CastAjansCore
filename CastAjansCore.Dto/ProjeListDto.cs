using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class ProjeListDto
    {
        public Musteri Musteri { get; set; }

        public List<Proje> Projeler { get; set; }
    }
}
