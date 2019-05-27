using Calbay.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CastAjansCore.Entity
{
    [Table("Kisiler", Schema = "Sistem")]
    public class Kisi : IEntity
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

        [Display(Name = "E-Posta")]
        [MaxLength(200)]
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

        [ForeignKey("UyrukId")]
        public virtual Uyruk Uyruk { get; set; }

        //public virtual Oyuncu Oyuncu { get; set; }

        //public virtual Supervisor Supervisor { get; set; }



    }
}
