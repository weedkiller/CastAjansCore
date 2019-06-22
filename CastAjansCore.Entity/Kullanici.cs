using Calbay.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Kullanicilar", Schema = "Sistem")]
    public class Kullanici : BaseEntity, IEntity
    {
        [Key]
        [ForeignKey("Kisi")]
        public override int Id { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [MaxLength(20)]
        [Required]
        public string KullaniciAdi { get; set; }

        [Display(Name = "Şifre")]
        [MaxLength(20)]
        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }

        public virtual Kisi Kisi { get; set; }
        public string Token { get; set; }
    }
}
