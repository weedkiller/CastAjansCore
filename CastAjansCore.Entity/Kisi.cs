using Calbay.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Kisiler", Schema = "Sistem")]
    public class Kisi : BaseEntity, IEntity
    {
        public int Id { get; set; }

        [MaxLength(11)]
        public string TC { get; set; }

        [Display(Name = "Adı")]
        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DogumTarihi { get; set; }

        [Display(Name = "Cinsiyet")]
        public EnuCinsiyet Cinsiyet { get; set; }

        [Display(Name = "Kan Grubu")]
        public EnuKanGrubu KanGrubu { get; set; }

        [Display(Name = "Uyruk")]
        public int? UyrukId { get; set; }

        [MaxLength(13)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon 1")]
        public string Telefon { get; set; }
        [MaxLength(13)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon 2")]
        public string Telefon2 { get; set; }

        [MaxLength(13)]
        [DataType(DataType.PhoneNumber)]
        public string Faks { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }

        [Display(Name = "İlçe")]
        public int? IlceId { get; set; }

        [ForeignKey("IlceId")]
        public virtual Ilce Ilce { get; set; }

        [MaxLength(4000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [MaxLength(200)]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }

        [Display(Name = "Web Sitesi")]
        [MaxLength(100)]
        public string WebSitesi { get; set; }

        [Display(Name = "Facebook")]
        [MaxLength(200)]
        public string FaceBook { get; set; }

        [MaxLength(200)]
        public string Twitter { get; set; }

        [MaxLength(200)]
        public string Instagram { get; set; }

        [MaxLength(200)]
        public string Linkedin { get; set; }

        public int? BankaId { get; set; }

        [MaxLength(4)]
        [Display(Name = "Şube Kodu")]
        public string SubeKodu { get; set; }

        [MaxLength(20)]
        [Display(Name = "Hesap Kodu")]
        public string HesapNumarasi { get; set; }

        [MaxLength(30)]
        [Display(Name = "İban")]
        public string Iban { get; set; }

        [ForeignKey("UyrukId")]
        public virtual Uyruk Uyruk { get; set; }

        //public virtual Oyuncu Oyuncu { get; set; }

        //public virtual Supervisor Supervisor { get; set; }



    }
}
