using CastAjansCore.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Dto
{
    public class OyuncuDetailDto
    {
        public int Id { get; set; }

        public string ProfilUrl { get; set; }

        [Display(Name = "Durumu")]
        public EnuKarakterDurumu KarakterDurumu { get; set; }

        [Display(Name = "TC")]
        public string Tc { get; set; }

        [Display(Name = "Adı")]
        public string Adi { get; set; }

        [Display(Name = "Soyadı")]
        public string Soyadi { get; set; }

        [Display(Name = "Ad Soyad")]
        public string TamAdi { get { return $"{Adi} {Soyadi}"; } }

        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [Display(Name = "Telefon")]
        public string Telefon { get; set; }

        [Display(Name = "İlçe")]
        public string Ilce { get; set; }

        [Display(Name = "Yaş")]
        public int Yas { get; set; }

        [Display(Name = "Boy(Cm)")]
        public int? Boy { get; set; }

        [Display(Name = "Kilo(Kg)")]
        public int? Kilo { get; set; }

        [Display(Name = "Alt Beden")]
        public int? AltBeden { get; set; }

        [Display(Name = "Üst Beden")]
        public int? UstBeden { get; set; }

        [Display(Name = "Ayak Numarası")]
        public int? AyakNumarasi { get; set; }

        [Display(Name = "Göz Rengi")]
        public EnuGozRengi? GozRengi { get; set; }

        [Display(Name = "Ten Rengi")]
        public EnuTenRengi? TenRengi { get; set; }

        [Display(Name = "Saç Rengi")]
        public EnuSacRengi? SacRengi { get; set; }

        [Display(Name = "Yabancı Dil")]
        public string YabanciDil { get; set; }

        [Display(Name = "Oyunculuk Eğitimi")]
        public string OyuculukEgitimi { get; set; }

        [Display(Name = "Tecrübeler")]
        public string Tecrubeler { get; set; }

        [Display(Name = "Yetenekler")]
        public string Yetenekleri { get; set; }

        [Display(Name = "Resimleri")]
        public List<string> OyuncuResimleri { get; set; }

        [Display(Name = "Videolari")]
        public List<string> OyuncuVideolari { get; set; }

        
    }
}