using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class KullaniciEditDto
    {
        public KullaniciEditDto()
        {
            Kullanici = new Kullanici();
            KisiEditDto = new KisiEditDto();

        }
        public Kullanici Kullanici { get; set; }

        public KisiEditDto KisiEditDto { get; set; }
    }
}
