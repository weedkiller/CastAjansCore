using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastAjansCore.Dto
{
    public class AdresListDto : IEntity
    {
        public int Id { get; set; }

        public bool Default { get; set; }

        public string Tanim { get; set; }

        public string Adress { get; set; }

        public IlceEditDto Ilce { get; set; }
    }
}
