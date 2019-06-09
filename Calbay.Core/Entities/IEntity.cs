using System;
using System.Collections.Generic;
using System.Text;

namespace Calbay.Core.Entities
{
    public interface IEntity
    {
        int Id { get; set; }

        int? EkleyenId { get; set; }

        DateTime EklemeZamani { get; set; }

        int? GuncelleyenId { get; set; }

        DateTime GuncellemeZamani { get; set; }

        bool Aktif { get; set; }
    }
}
