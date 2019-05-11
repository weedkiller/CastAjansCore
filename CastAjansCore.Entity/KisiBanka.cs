using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastAjansCore.Entity
{
    [Table("KisiBankalari", Schema = "Sistem")]
    public class KisiBanka : BaseEntity
    {
        public int KisiId { get; set; }

        public int BankaId { get; set; }

        public string SubeKodu { get; set; }

        public string HesapNumarasi { get; set; }

        public string Iban { get; set; }

        [ForeignKey("KisiId")]
        public virtual Kisi Kisi { get; set; }

        [ForeignKey("BankaId")]
        public virtual Banka Banka { get; set; }


    }
}