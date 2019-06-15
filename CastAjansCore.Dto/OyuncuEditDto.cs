using CastAjansCore.Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CastAjansCore.Dto
{
    public class OyuncuEditDto
    {
        public OyuncuEditDto()
        {
            KisiEditDto = new KisiEditDto();
            OyuncuResimleri = new List<OyuncuResim>();
            OyuncuVideolari = new List<OyuncuVideo>();
        }
        public Oyuncu Oyuncu { get; set; }

        public KisiEditDto KisiEditDto { get; set; }

        public List<OyuncuResim> OyuncuResimleri { get; set; }

        public List<OyuncuVideo>  OyuncuVideolari { get; set; }

        public List<IFormFile> OyuncuResimleriFile { get; set; }

        public List<IFormFile> OyuncuVideolariFile { get; set; }

    }
}
