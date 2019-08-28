﻿using System.ComponentModel.DataAnnotations;

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
        Dul = 2
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
        Yesil = 2,

        [Display(Name = "Ela")]
        Ela = 3,

        [Display(Name = "Kahve")]
        Kahve = 4,

        [Display(Name = "Koyu Kahve")]
        KoyuKahve = 5,

        [Display(Name = "Siyah")]
        Siyah = 6
    }

    public enum EnuTenRengi
    {
        [Display(Name = "-")]
        Seciniz = 0,

        [Display(Name = "Beyaz")]
        Beyaz = 1,

        [Display(Name = "Sarışın")]
        Sarışın = 2,

        [Display(Name = "Esmer")]
        Esmer = 2,

        [Display(Name = "Kumral")]
        Kumral = 3,

        [Display(Name = "Siyahi")]
        Siyahi = 4
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
        Platin = 13
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
        Gazete = 3,

        [Display(Name = "Dergi")]
        Dergi = 3,
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
        [Display(Name = "Teklif Atıldı")]
        Aktif = 1,

        [Display(Name = "Kabul Edildi")]
        Pasif = 2
    }

    public enum EnuCastTipi
    {
        [Display(Name = "Seçiniz")]
        Seciniz = 0,

        [Display(Name = "Yardımcı Oyuncu")]
        YardımciOyuncu = 1,

        [Display(Name = "Ön SGV")]
        OnSgv = 2,

        [Display(Name = "Ana Cast")]
        AnaCast = 3
    }





}
