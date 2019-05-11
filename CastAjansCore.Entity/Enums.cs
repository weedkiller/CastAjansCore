using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CastAjansCore.Entity
{
    public enum EnuCinsiyet
    {
        [Display(Name = "Seçiniz")]
        Seciniz = 0,

        [Display(Name = "Bayan")]
        Bayan = 1,

        [Display(Name = "Bay")]
        Bay = 2
    }

    public enum EnuMedeniDurumu
    {
        [Display(Name = "Seçiniz")]
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
        [Display(Name = "Seçiniz")]
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
        KoyuKahve = 5
    }

    public enum EnuTenRengi
    {
        [Display(Name = "Seçiniz")]
        Seciniz = 0,

        [Display(Name = "Beyaz")]
        Beyaz = 1,

        [Display(Name = "Sarışın")]
        Sarışın = 2,

        [Display(Name = "Esmer")]
        Esmer = 2,

        [Display(Name = "Kumral")]
        Kumral = 3,

    }

    public enum EnuSacRengi
    {
        [Display(Name = "Seçiniz")]
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
        [Display(Name = "Seçiniz")]
        Seciniz = 0,

        [Display(Name = "A Rh Pozitif")]
        APozitif = 1,

        [Display(Name = "A Rh Negetif")]
        ANegatif = 2,

        [Display(Name = "AB Rh Pozitif")]
        ABPozitif = 3,

        [Display(Name = "AB Rh Negetif")]
        ABNegatif = 4,

        [Display(Name = "B Rh Pozitif")]
        BPozitif = 5,

        [Display(Name = "B Rh Negetif")]
        BNegatif = 6,
        [Display(Name = "0 Rh Pozitif")]
        SifirPozitif = 7,

        [Display(Name = "0 Rh Negetif")]
        SifirNegatif = 8,
    }
    public enum EnuIsTipi
    {
        [Display(Name = "Seçiniz")]
        Seciniz = 0,

        [Display(Name = "Dizi")]
        Dizi = 1,

        [Display(Name = "Film")]
        Film = 2,

        [Display(Name = "Reklam")]
        Reklam = 3
    }

    public enum EnuMecra
    {
        [Display(Name = "Seçiniz")]
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

    public enum EnuTelefonTuru
    {
        [Display(Name = "Cep")]
        Cep = 1,

        [Display(Name = "Ev")]
        Ev = 2,

        [Display(Name = "İş")]
        Is = 3
    }


}
