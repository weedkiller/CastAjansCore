using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class IlceListDto
    {
        public Il Il { get; set; }

        public List<Ilce> Ilceler { get; set; }
    }
}
