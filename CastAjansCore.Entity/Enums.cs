using System.ComponentModel.DataAnnotations;

namespace CastAjansCore.Entity
{
    public enum EnuCinsiyet
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Bayan")]
        Bayan = 1,

        [Display(Name = "Bay")]
        Bay = 2
    }

    public enum EnuMedeniDurumu
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Bekâr")]
        Bekar = 1,

        [Display(Name = "Evli")]
        Evli = 2,

        [Display(Name = "Dul")]
        Dul = 3
    }

    public enum EnuGozRengi
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Gri")]
        Gri = 1,

        [Display(Name = "Mavi")]
        Mavi = 2,

        [Display(Name = "Yeşil")]
        Yesil = 3,

        [Display(Name = "Ela")]
        Ela = 4,

        [Display(Name = "Kahve")]
        Kahve = 5,

        [Display(Name = "Koyu Kahve")]
        KoyuKahve = 6,

        [Display(Name = "Siyah")]
        Siyah = 7
    }

    public enum EnuTenRengi
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Beyaz")]
        Beyaz = 1,

        [Display(Name = "Sarışın")]
        Sarısın = 2,

        [Display(Name = "Esmer")]
        Esmer = 3,

        [Display(Name = "Kumral")]
        Kumral = 4,

        [Display(Name = "Siyahi")]
        Siyahi = 5,

        [Display(Name = "Buğday")]
        Bugday = 6
    }

    public enum EnuSacTipi
    {
        [Display(Name = "Kısa")]
        Kisa = 1,

        [Display(Name = "Uzun")]
        Uzun = 2,

        [Display(Name = "Çok Uzun")]
        CokUzun = 3,

        [Display(Name = "Seyrek")]
        Seyrek = 4,

        [Display(Name = "Kel")]
        Kel = 5,

        [Display(Name = "Rasta")]
        Rasta = 6,

        [Display(Name = "Kıvırcık")]
        Kivircik = 7

    }

    public enum EnuSacRengi
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Beyaz")]
        Beyaz = 1,

        [Display(Name = "Sarı")]
        Sarı = 2,

        [Display(Name = "Siyah")]
        Siyah = 3,

        [Display(Name = "Kızıl")]
        Kizil = 4,

        [Display(Name = "Kahverengi")]
        Kahverengi = 5,

        [Display(Name = "Mor")]
        Mor = 6,

        [Display(Name = "Kumral")]
        Kumral = 7,

        [Display(Name = "Açık Kumral")]
        AcikkKumral = 8,

        [Display(Name = "Pembe")]
        Pembe = 9,

        [Display(Name = "Yeşil")]
        Yesil = 10,

        [Display(Name = "Mavi")]
        Mavi = 11,

        [Display(Name = "Kestane")]
        Kestane = 12,

        [Display(Name = "Platin")]
        Platin = 13,

        [Display(Name = "Kır")]
        Kir = 14
    }

    public enum EnuKanGrubu
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "A Rh(+)")]
        APozitif = 1,

        [Display(Name = "A Rh(-)")]
        ANegatif = 2,

        [Display(Name = "B Rh(+)")]
        BPozitif = 3,

        [Display(Name = "B Rh(-)")]
        BNegatif = 4,

        [Display(Name = "AB Rh(+)")]
        ABPozitif = 5,

        [Display(Name = "AB Rh(-)")]
        ABNegatif = 6,

        [Display(Name = "0 Rh(+)")]
        SifirPozitif = 7,

        [Display(Name = "0 Rh(-)")]
        SifirNegatif = 8,
    }
    public enum EnuIsTipi
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Reklam")]
        Reklam = 1,

        [Display(Name = "Dizi")]
        Dizi = 2,

        [Display(Name = "Kamu Spotu")]
        KamuSpotu = 3,

        [Display(Name = "Sinema")]
        Sinema = 4,

        [Display(Name = "Kısa Film")]
        KisaFilm = 5
    }

    public enum EnuMecra
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Tv")]
        Tv = 1,

        [Display(Name = "İnternet")]
        Internet = 2,

        [Display(Name = "Radyo")]
        Radyo = 3,

        [Display(Name = "Gazete")]
        Gazete = 4,

        [Display(Name = "Dergi")]
        Dergi = 5
    }

    public enum EnuProjeDurumu
    {
        [Display(Name = "Hazırlık Aşamasında")]
        HazirlikAsamasinda = 1,

        [Display(Name = "Mail Gönder")]
        MailGonder = 2,

        [Display(Name = "Teklif Atıldı")]
        TeklifAtildi = 3,

        [Display(Name = "Onaylandı")]
        Onaylandi = 4,

        [Display(Name = "Tamamlandı")]
        Tamamlandi = 5,

        [Display(Name = "Onaylanmadı")]
        Onaylanmadi = 6
    }

    //public enum EnuTelefonTuru
    //{
    //    [Display(Name = "Cep")]
    //    Cep = 1,

    //    [Display(Name = "Ev")]
    //    Ev = 2,

    //    [Display(Name = "İş")]
    //    Is = 3
    //}

    public enum EnuKarakterDurumu
    {
        [Display(Name = "Teklif Atıldı")]
        TeklifAtildi = 1,

        [Display(Name = "Kabul Edildi")]
        KabulEdildi = 2,

        [Display(Name = "Oynadı")]
        Oynadi = 3
    }

    public enum EnuOyuncuDurumu
    {
        [Display(Name = "Aktif")]
        Aktif = 1,

        [Display(Name = "Pasif")]
        Pasif = 2
    }

    public enum EnuCastTipi
    {
        //[Display(Name = "Seçiniz")]
        //Seciniz = 0,

        [Display(Name = "Yardımcı Oyuncu")]
        YardımciOyuncu = 1,

        [Display(Name = "Ön FGR")]
        FGR = 2,

        [Display(Name = "Ana Cast")]
        AnaCast = 3
    }
}
