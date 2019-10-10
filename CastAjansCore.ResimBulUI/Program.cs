using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Business.Concrete;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using CastAjansCore.Entity;
using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.ResimBulUI
{

    class Program
    {
        private static string webRootPath;
        private static IOyuncuServis _oyuncuServis = new OyuncuManager(
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
        private static IOyuncuResimServis _oyuncuResimServis = new OyuncuResimManager(new EfOyuncuResimDal());
        private static IOyuncuVideoServis _oyuncuVideoServis = new OyuncuVideoManager(new EfOyuncuVideoDal());

        static async Task Main(string[] args)
        {
            try
            {

                //ResimYukle();
                await VideoYukleAsync();
                //Oriantetion("C:\\inetpub\\wwwroot\\CastAjans\\wwwroot\\Dosyalar\\2019\\7\\Resimler\\OyuncuResimleri\\1992-Abdullah Balcı (3).JPG");

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("Bitti {0}", DateTime.Now);
            Console.ReadLine();
        }

        private void Test()
        {
            var directoriesBozuk = ImageMetadataReader.ReadMetadata(@"C:\Projeler\CastAjansCore\CastAjansCore.WebUI\wwwroot\Dosyalar\2019\7\Resimler\OyuncuResimleri\1992-Abdullah Balcı (3).JPG");
            var directories = ImageMetadataReader.ReadMetadata(@"C:\Projeler\CastAjansCore\CastAjansCore.WebUI\wwwroot\Dosyalar\2019\7\Resimler\OyuncuResimleri1\1992-Abdullah Balcı (3).JPG");


            foreach (var directory in directoriesBozuk)
            {
                var dDuzgun = directories.Where(i => i.Name == directory.Name).FirstOrDefault();
                if (dDuzgun == null)
                {
                    Console.WriteLine($"Bulunamadı {directory.Name}");
                    foreach (var tag in directory.Tags)
                    {
                        Console.WriteLine($"Bulunamadı {tag.TagName}:{tag.Description}");
                    }
                }
                foreach (var tag in directory.Tags)
                {
                    var tDuzgun = dDuzgun.Tags.Where(t => t.TagName == tag.TagName).FirstOrDefault();
                    if (tDuzgun == null)
                    {
                        Console.WriteLine($"Bulunamadı {tag.TagName}");
                    }
                    if (tDuzgun.Description != tag.Description)
                    {
                        Console.WriteLine($"{directory.Name} - {tag.TagName}:{tag.Description} olması gereken:{tDuzgun.Description}");
                    }

                }


            }
        }

        private static void Oriantetion(string pathToImageFile)
        {
            // Rotate the image according to EXIF data
            //var bmp = new Bitmap(pathToImageFile);

            var directories = ImageMetadataReader.ReadMetadata(pathToImageFile);
            foreach (var directory in directories.Where(i => i.Name.Contains("Exif")))
            {
                //var tag = directory.Tags.Where(t => t.TagName.Contains("Orientation")).FirstOrDefault();
                foreach (var tag in directory.Tags)
                {
                    Console.WriteLine($"{directory.Name} - {tag.Name} = {tag.Description}");
                }

            }
            Console.ReadLine();

            //if (exif["Orientation"] != null)
            //{
            //bmp.PropertyItems.Where(i => i.Id == 0x112).FirstOrDefault().Value[0] = 1;
            //bmp.Save(pathToImageFile+"123", ImageFormat.Jpeg);

            //if (flip != RotateFlipType.RotateNoneFlipNone) // don't flip of orientation is correct
            //{
            //    bmp.RotateFlip(flip);
            //    //exif.setTag(0x112, "1"); // Optional: reset orientation tag

            //}

            //    // Match the orientation code to the correct rotation:


            //}

        }

        private static RotateFlipType OrientationToFlipType(string orientation)
        {
            switch (int.Parse(orientation))
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
                    break;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                    break;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                    break;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                    break;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                    break;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                    break;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                    break;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }

        private static void ResimYukle()
        {
            UserHelper userHelper = new UserHelper
            {
                Id = 1
            };
            webRootPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");


            var dosyalar = System.IO.Directory.EnumerateFiles(@"c:\\Resimler", "*", SearchOption.AllDirectories);

            List<Oyuncu> oyuncular = _oyuncuServis.GetList(k => k.Kisi.ProfilFotoUrl == null && k.Aktif == true && k.Kisi.Aktif == true);
            //List<Oyuncu> oyuncular = oyuncuServis.GetList(k => k.Kisi.Adi.StartsWith("OSMAN") && k.Kisi.Soyadi.StartsWith("KERİMOĞLU") && k.Aktif == true && k.Kisi.Aktif == true);
            int i = 0;
            foreach (var oyuncu in oyuncular)
            {
                if (i % 250 == 0)
                    Console.WriteLine($"%{i - 100 / oyuncular.Count} ({i} / {oyuncular.Count})");
                i++;

                List<OyuncuResim> resimler = new List<OyuncuResim>();

                string yil = "";
                if (oyuncu.Kisi.DogumTarihi != null && oyuncu.Kisi.DogumTarihi.Value.Year != 1905)
                {
                    yil = oyuncu.Kisi.DogumTarihi.Value.Year.ToString();
                }

                List<string> files = dosyalar.Where(d =>
                    (yil != "" || d.StartsWith(yil)) &&
                    d.ToLower().TurkceKarakterdenDonustur()
                     .Contains($"{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}".ToLower().TurkceKarakterdenDonustur())
                    ).ToList();

                if (files.Count == 0)
                {
                    Console.WriteLine($"Bulunamadı {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}");
                }
                else
                {
                    List<string> control = files.GroupBy(g => g.Substring(13, 4)).Select(g => g.Key).ToList();

                    if (control.Count > 1)
                    {
                        Console.WriteLine($"Çift Kayıt {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}");
                        foreach (var resim in files)
                        {
                            SaveFile(resim, "CiftKayit");
                        }
                    }
                    else
                    {
                        DateTime minDate = DateTime.Now;
                        foreach (var resim in files)
                        {
                            FileInfo fi = new FileInfo(resim);
                            if (minDate > fi.CreationTime)
                                minDate = fi.CreationTime;


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
                            if (int.TryParse(control[0], out int n))
                            {
                                if (oyuncu.Kisi.DogumTarihi == null)
                                    oyuncu.Kisi.DogumTarihi = new DateTime(control[0].ToInt(), 1, 1);
                                else
                                    oyuncu.Kisi.DogumTarihi = new DateTime(control[0].ToInt(), oyuncu.Kisi.DogumTarihi.Value.Month, oyuncu.Kisi.DogumTarihi.Value.Day);
                            }
                            if (oyuncu.EklemeZamani > minDate)
                            {
                                oyuncu.EklemeZamani = minDate;
                                oyuncu.Kisi.EklemeZamani = minDate;
                            }
                            _oyuncuServis.UpdateAsync(oyuncu, userHelper);
                            _oyuncuResimServis.SaveListAsync(resimler, userHelper);
                        }
                    }
                }
            }
        }

        private static async Task VideoYukleAsync()
        {
            UserHelper userHelper = new UserHelper
            {
                Id = 1
            };
            webRootPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");


             
            var dosyalar = System.IO.Directory.EnumerateFiles(@"c:\\Videolar", "*", SearchOption.AllDirectories);

            List<Oyuncu> oyuncular = _oyuncuServis.GetList(k => k.Aktif == true && k.Kisi.Aktif == true);
            //List<Oyuncu> oyuncular = oyuncuServis.GetList(k => k.Kisi.Adi.StartsWith("OSMAN") && k.Kisi.Soyadi.StartsWith("KERİMOĞLU") && k.Aktif == true && k.Kisi.Aktif == true);
            int i = 0;
            foreach (var oyuncu in oyuncular)
            {
                if (i % 250 == 0)
                    Console.WriteLine($"%{i - 100 / oyuncular.Count} ({i} / {oyuncular.Count})");
                i++;

                List<OyuncuVideo> videolar = new List<OyuncuVideo>();

                string yil = "";
                if (oyuncu.Kisi.DogumTarihi != null && oyuncu.Kisi.DogumTarihi.Value.Year != 1905)
                {
                    yil = oyuncu.Kisi.DogumTarihi.Value.Year.ToString();
                }

                List<string> files = dosyalar.Where(d =>
                    (yil != "" || d.StartsWith(yil)) &&
                    d.ToLower().TurkceKarakterdenDonustur()
                     .Contains($"{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}".ToLower().TurkceKarakterdenDonustur())
                    ).ToList();

                if (files.Count == 0)
                {
                    Console.WriteLine($"Bulunamadı {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}");
                }
                else
                {
                    List<string> control = files.GroupBy(g => g.Substring(13, 4)).Select(g => g.Key).ToList();

                    if (control.Count > 1)
                    {
                        Console.WriteLine($"Çift Kayıt {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}");
                        foreach (var resim in files)
                        {
                            SaveFile(resim, "CiftKayit");
                        }
                    }
                    else
                    {
                        DateTime minDate = DateTime.Now;
                        foreach (var resim in files)
                        {
                            FileInfo fi = new FileInfo(resim);
                            if (minDate > fi.CreationTime)
                                minDate = fi.CreationTime;


                            videolar.Add(new OyuncuVideo
                            {
                                OyuncuId = oyuncu.Id,
                                DosyaYolu = SaveFile(resim, "OyuncuVideolari"),
                                EklemeZamani = fi.CreationTime,
                                GuncellemeZamani = fi.CreationTime
                            });
                        }

                        if (videolar.Count > 0)
                        { 
                           await _oyuncuVideoServis.SaveListAsync(videolar, userHelper);
                        }
                    }
                }
            }
        }

        private static void Eski()
        {
            UserHelper userHelper = new UserHelper
            {
                Id = 1
            };
            webRootPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");


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
                        files.AddRange(System.IO.Directory.EnumerateFiles(@"c:\\Resimler", item, SearchOption.AllDirectories));
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

        private static List<string> GetFileNames(Oyuncu oyuncu)
        {
            List<string> str = new List<string>
            {
                $"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi} {oyuncu.Kisi.Soyadi}*",

                $"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
                $"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*"
            };

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

                tasinacakyer = $"Dosyalar/{DateTime.Now.Year}/{DateTime.Now.Month}/{tasinacakyer}";
                string path = Path.Combine(webRootPath, tasinacakyer.Replace("/", "\\"));

                // file is uploaded
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
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
