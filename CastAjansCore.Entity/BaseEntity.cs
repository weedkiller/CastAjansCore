using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastAjansCore.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public int? EkleyenId { get; set; }

        public DateTime EklemeZamani { get; set; }

        public int? GuncelleyenId { get; set; }

        public DateTime GuncellemeZamani { get; set; }

        public bool Aktif { get; set; }

        [ForeignKey("EkleyenId")]
        public virtual Kisi Ekleyen { get; set; }

        [ForeignKey("GuncelleyenId")]
        public virtual Kisi Guncelleyen { get; set; }
    }
}
