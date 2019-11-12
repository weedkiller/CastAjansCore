using System;

namespace CastAjansCore.Entity
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }

        public int? EkleyenId { get; set; }

        public DateTime EklemeZamani { get; set; }

        public int? GuncelleyenId { get; set; }

        public DateTime GuncellemeZamani { get; set; }

        public bool Aktif { get; set; } = true;

    }
}
