using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Business.Concrete;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CastAjansCore.ResimBulUI
{

    class Program
    {
        private static string webRootPath;

        static void Main(string[] args)
        {
            try
            {


                UserHelper userHelper = new UserHelper
                {
                    Id = 1
                };
                webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");


                IOyuncuServis oyuncuServis = new OyuncuManager(
                        new EfOyuncuDal(),
                        new KisiManager(new EfKisiDal(),
                                        new IlManager(new EfIlDal()),
                                        new IlceManager(new EfIlceDal()),
                                        new UyrukManager(new EfUyrukDal()),
                                        new BankaManager(new EfBankaDal())
                                        ),
                        new OyuncuResimManager(new EfOyuncuResimDal()),
                        new OyuncuVideoManager(new EfOyuncuVideoDal())
                        );
                IOyuncuResimServis oyuncuResimServis = new OyuncuResimManager(new EfOyuncuResimDal());

                List<Oyuncu> oyuncular = oyuncuServis.GetList(k => k.Kisi.ProfilFotoUrl == null && k.Aktif == true && k.Kisi.Aktif == true);
                int i = 0;
                foreach (var oyuncu in oyuncular)
                {

                    if (i % 250 == 0)
                        Console.WriteLine($"{i} / {oyuncular.Count}");
                    i++;

                    if (oyuncu.Kisi.DogumTarihi != null)
                    {     
                        List<string> files = new List<string>();
                        var str = GetFileNames(oyuncu);
                        foreach (var item in str)
                        {
                            files.AddRange(Directory.EnumerateFiles(@"c:\\Resimler", item, SearchOption.AllDirectories));
                        }

                        List<OyuncuResim> resimler = new List<OyuncuResim>();
                        foreach (var resim in files.Distinct())
                        {
                            FileInfo fi = new FileInfo(resim);
                            resimler.Add(new OyuncuResim
                            {
                                OyuncuId = oyuncu.Id,
                                DosyaYolu = SaveFile(resim, "OyuncuResimleri"),
                                EklemeZamani = fi.CreationTime,
                                GuncellemeZamani = fi.CreationTime
                            });
                        }



                        if (resimler.Count > 0)
                        {
                            oyuncu.Kisi.ProfilFotoUrl = resimler[0].DosyaYolu;
                            oyuncuServis.UpdateAsync(oyuncu, userHelper);
                            oyuncuResimServis.SaveListAsync(resimler, userHelper);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("Bitti {0}", DateTime.Now);
            Console.ReadLine();
        }

        private static List<string> GetFileNames(Oyuncu oyuncu)
        {
            List<string> str = new List<string>();
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*");

            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*");

            if (oyuncu.Kisi.Adi.ToLower().Contains("ı") || oyuncu.Kisi.Soyadi.ToLower().Contains("ı"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("i") || oyuncu.Kisi.Soyadi.ToLower().Contains("i"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
            }



            if (oyuncu.Kisi.Adi.ToLower().Contains("o") || oyuncu.Kisi.Soyadi.ToLower().Contains("o"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("ö") || oyuncu.Kisi.Soyadi.ToLower().Contains("ö"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("u") || oyuncu.Kisi.Soyadi.ToLower().Contains("u"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("ü") || oyuncu.Kisi.Soyadi.ToLower().Contains("ü"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("c") || oyuncu.Kisi.Soyadi.ToLower().Contains("c"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("ç") || oyuncu.Kisi.Soyadi.ToLower().Contains("ç"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("g") || oyuncu.Kisi.Soyadi.ToLower().Contains("g"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("ğ") || oyuncu.Kisi.Soyadi.ToLower().Contains("ğ"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("s") || oyuncu.Kisi.Soyadi.ToLower().Contains("s"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
            }

            if (oyuncu.Kisi.Adi.ToLower().Contains("ş") || oyuncu.Kisi.Soyadi.ToLower().Contains("ş"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
            }


            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*");
            str.Add($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*");

            if (oyuncu.Kisi.Adi.ToUpper().Contains("I") || oyuncu.Kisi.Soyadi.ToUpper().Contains("I"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("I", "İ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("I", "İ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("I", "İ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("I", "İ"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("İ") || oyuncu.Kisi.Soyadi.ToUpper().Contains("İ"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("İ", "I"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("İ", "I"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("İ", "I"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("İ", "I"));
            }



            if (oyuncu.Kisi.Adi.ToUpper().Contains("O") || oyuncu.Kisi.Soyadi.ToUpper().Contains("O"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("O", "Ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("O", "Ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("O", "Ö"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("O", "Ö"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("Ö") || oyuncu.Kisi.Soyadi.ToUpper().Contains("Ö"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ö", "O"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ö", "O"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ö", "O"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ö", "O"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("U") || oyuncu.Kisi.Soyadi.ToUpper().Contains("U"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("U", "Ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("U", "Ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("U", "Ü"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("U", "Ü"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("Ü") || oyuncu.Kisi.Soyadi.ToUpper().Contains("Ü"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ü", "U"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ü", "U"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ü", "U"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ü", "U"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("C") || oyuncu.Kisi.Soyadi.ToUpper().Contains("C"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("C", "Ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("C", "Ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("C", "Ç"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("C", "Ç"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("Ç") || oyuncu.Kisi.Soyadi.ToUpper().Contains("Ç"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ç", "C"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ç", "C"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ç", "C"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ç", "C"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("G") || oyuncu.Kisi.Soyadi.ToUpper().Contains("G"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("G", "Ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("G", "Ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("G", "Ğ"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("G", "Ğ"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("Ğ") || oyuncu.Kisi.Soyadi.ToUpper().Contains("Ğ"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ğ", "G"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ğ", "G"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ğ", "G"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ğ", "G"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("S") || oyuncu.Kisi.Soyadi.ToUpper().Contains("S"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("S", "Ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("S", "Ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("S", "Ş"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("S", "Ş"));
            }

            if (oyuncu.Kisi.Adi.ToUpper().Contains("Ş") || oyuncu.Kisi.Soyadi.ToUpper().Contains("Ş"))
            {
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ş", "S"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ş", "S"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ş", "S"));
                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToUpper()} {oyuncu.Kisi.Soyadi.ToUpper()}*").Replace("Ş", "S"));
            }


            return str;
        }

        public static string SaveFile(string kaynakyer, string tasinacakyer)
        {
            if (kaynakyer != null)
            {
                //string pic = Path.GetFileName(file.FileName);

                tasinacakyer = $"Dosyalar/{DateTime.Now.Year}/{DateTime.Now.Month}/Resimler/{tasinacakyer}";
                string path = Path.Combine(webRootPath, tasinacakyer.Replace("/", "\\"));

                // file is uploaded
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string dosyaAdi = Path.GetFileName(kaynakyer);
                path = Path.Combine(path, dosyaAdi);
                File.Move(kaynakyer, path);

                return String.Format("/{0}/{1}", tasinacakyer, dosyaAdi);
            }
            else
            {
                return null;
            }
        }

    }
}
