using Calbay.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CastAjansCore.Entity
{
    [Table("Kisiler", Schema = "Sistem")]
    public class Kisi : IEntity
    {
        public int Id { get; set; }

        [MaxLength(11)]
        public string TC { get; set; }

        [Required]
        [MaxLength(50)]
        public string Adi { get; set; }

        [Required]
        [MaxLength(50)]
        public string Soyadi { get; set; }
        
        public DateTime DogumTarihi { get; set; }

        public EnuCinsiyet Cinsiyet { get; set; }

        public EnuKanGrubu KanGrubu { get; set; }

        public int UyrukId { get; set; }

        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EPosta { get; set; }

        [MaxLength(100)]
        public string WebSitesi { get; set; }

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
