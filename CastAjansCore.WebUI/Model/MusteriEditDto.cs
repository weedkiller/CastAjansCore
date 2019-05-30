using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.WebUI.Model
{
    public class MusteriEditDto
    {
        public MusteriEditDto()
        {
            Musteri = new Musteri();
            Iller = new List<Il>();
        }
        public Musteri Musteri { get; set; }

        public List<Il> Iller { get; set; }
    }
}
