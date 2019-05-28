using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Model
{
    public class MusteriEditDto
    {
        public MusteriEditDto()
        {
            Musteri = new Musteri();
            Kisi = new KisiEditDto();
        }
        public Musteri Musteri { get; set; }

        public List<Il> Kisi { get; set; }
    }
}
