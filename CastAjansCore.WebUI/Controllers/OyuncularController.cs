using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin,calisan")]
    public class OyuncularController : Controller
    {
        private readonly IOyuncuServis _OyuncuServis;
        private readonly LoginHelper _loginHelper;
        private readonly IUyrukServis _uyrukServis;
        private readonly IIlServis _ilServis;
        private readonly IOyuncuResimServis _oyuncuResimServis;

        //private readonly IHostingEnvironment _HostingEnvironment;
        public OyuncularController(
            IOyuncuServis OyuncuServis,
            IUyrukServis uyrukServis,
            IIlServis ilServis,
            IOyuncuResimServis oyuncuResimServis,
            LoginHelper loginHelper
        )
        {
            _OyuncuServis = OyuncuServis;
            //_HostingEnvironment = environment;
            _loginHelper = loginHelper;
            _uyrukServis = uyrukServis;
            _ilServis = ilServis;
            _oyuncuResimServis = oyuncuResimServis;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        public async Task<IActionResult> Index()
        {

            //var Oyuncular = await _OyuncuServis.GetListDtoAsync();
            //return View(Oyuncular);

            OyuncuFilterDto oyuncuFilterDto = new OyuncuFilterDto
            {
                Uyruklar = await _uyrukServis.GetSelectListAsync(),
                Iller = await _ilServis.GetSelectListAsync()
            };

            return View(oyuncuFilterDto);
        }

        // GET: Oyuncus/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var entity = await _OyuncuServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Oyuncus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            OyuncuEditDto model = await _OyuncuServis.GetEditDtoAsync(id);

            if (id != null && model.Oyuncu == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Oyuncus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, OyuncuEditDto oyuncuEditDto)
        {
            try
            {
                ModelState.Remove("Oyuncu.Id");
                ModelState.Remove("Oyuncu.Sactipi");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");
                

                if (ModelState.IsValid)
                {
                    try
                    {
                        Oyuncu Oyuncu = oyuncuEditDto.Oyuncu;
                        Oyuncu.CT_AnaCast = false;
                        Oyuncu.CT_OnFGR = false;
                        Oyuncu.CT_YardımciOyuncu = false;
                        if (oyuncuEditDto.CastTipleri.IsNotNull())
                        {
                            foreach (EnuCastTipi item in oyuncuEditDto.CastTipleri)
                            {
                                switch (item)
                                {
                                    case EnuCastTipi.YardımciOyuncu:
                                        Oyuncu.CT_YardımciOyuncu = true;
                                        break;
                                    case EnuCastTipi.FGR:
                                        Oyuncu.CT_OnFGR = true;
                                        break;
                                    case EnuCastTipi.AnaCast:
                                        Oyuncu.CT_AnaCast = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        Oyuncu.Kisi = oyuncuEditDto.KisiEditDto.Kisi;

                        if (oyuncuEditDto.KisiEditDto.ProfilFotoFile != null)
                        {
                            oyuncuEditDto.KisiEditDto.Kisi.ProfilFotoUrl = oyuncuEditDto.KisiEditDto.ProfilFotoFile.SaveFile("OyuncuResimleri");
                            if (oyuncuEditDto.Oyuncu.OyuncuResimleri == null)
                            {
                                oyuncuEditDto.Oyuncu.OyuncuResimleri = new List<OyuncuResim>();
                            }

                            oyuncuEditDto.Oyuncu.OyuncuResimleri.Add(new OyuncuResim { DosyaYolu = oyuncuEditDto.KisiEditDto.Kisi.ProfilFotoUrl });
                        }

                        if (oyuncuEditDto.KisiEditDto.KimlikOnFile != null)
                            oyuncuEditDto.KisiEditDto.Kisi.KimlikOnUrl = oyuncuEditDto.KisiEditDto.KimlikOnFile.SaveFile("Kimlikler");

                        if (oyuncuEditDto.KisiEditDto.KimlikArkaFile != null)
                            oyuncuEditDto.KisiEditDto.Kisi.KimlikArkaUrl = oyuncuEditDto.KisiEditDto.KimlikArkaFile.SaveFile("Kimlikler");


                        if (oyuncuEditDto.OyuncuResimleriFile != null && oyuncuEditDto.OyuncuResimleriFile.Count > 0)
                        {
                            if (oyuncuEditDto.Oyuncu.OyuncuResimleri == null)
                            {
                                oyuncuEditDto.Oyuncu.OyuncuResimleri = new List<OyuncuResim>();
                            }
                            foreach (var item in oyuncuEditDto.OyuncuResimleriFile)
                            {
                                oyuncuEditDto.Oyuncu.OyuncuResimleri.Add(
                                    new OyuncuResim { DosyaYolu = item.SaveFile("OyuncuResimleri") }
                                    );
                            }
                        }

                        if (oyuncuEditDto.OyuncuVideolariFile != null && oyuncuEditDto.OyuncuVideolariFile.Count > 0)
                        {
                            oyuncuEditDto.Oyuncu.OyuncuVideolari = new List<OyuncuVideo>();
                            foreach (var item in oyuncuEditDto.OyuncuVideolariFile)
                            {
                                oyuncuEditDto.Oyuncu.OyuncuVideolari.Add(
                                    new OyuncuVideo { DosyaYolu = item.SaveFile("OyuncuVideolari") }
                                    );
                            }
                        }

                        if (id == null)
                        {
                            await _OyuncuServis.AddAsync(Oyuncu, _loginHelper.UserHelper);
                        }
                        else
                        {
                            if (id != Oyuncu.Id)
                            {
                                return NotFound();
                            }
                            await _OyuncuServis.UpdateAsync(Oyuncu, _loginHelper.UserHelper);
                        }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await OyuncuExistsAsync(oyuncuEditDto.Oyuncu.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                MesajHelper.HataEkle(ViewBag, ex.Message);
            }

            var combolar = await _OyuncuServis.GetEditDtoAsync(id);
            oyuncuEditDto.KisiEditDto.Ilceler = combolar.KisiEditDto.Ilceler;
            oyuncuEditDto.KisiEditDto.Iller = combolar.KisiEditDto.Iller;
            oyuncuEditDto.KisiEditDto.Uyruklar = combolar.KisiEditDto.Uyruklar;
            return View(oyuncuEditDto);
        }

        public async Task<IActionResult> ResimDelete(int id, int resimId)
        {
            await _oyuncuResimServis.DeleteAsync(resimId, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Edit), new { id });
        }

        public async Task<IActionResult> AnaResimYap(int id, int resimId)
        {
            await _OyuncuServis.AnaResimYap(id, resimId, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Edit), new { id });
        }

        public string ResimCevir(string resimUrl)
        {
            try
            {
                //var resim = await _oyuncuResimServis.GetByIdAsync(resimId);
                var resimPath = FileHelper._WebRootPath + resimUrl.Replace('/', '\\');
                Bitmap bitmap = new Bitmap(resimPath);
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                bitmap.Save(resimPath);

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        //public async Task<IActionResult> ResimBulAsync()
        //{
        //    var oyuncular = await _OyuncuServis.GetListAsync(i => i.Kisi.ProfilFotoUrl == null && i.Aktif == true && i.Kisi.Aktif == true);
        //    foreach (var oyuncu in oyuncular)
        //    {
        //        if (oyuncu.Kisi.DogumTarihi != null)
        //        {


        //            List<string> str = new List<string>
        //            {
        //                $"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
        //                $"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
        //                $"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*",
        //                $"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*"
        //            };

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ı") || oyuncu.Kisi.Soyadi.ToLower().Contains("ı"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ı", "i"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("i") || oyuncu.Kisi.Soyadi.ToLower().Contains("i"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("i", "ı"));
        //            }



        //            if (oyuncu.Kisi.Adi.ToLower().Contains("o") || oyuncu.Kisi.Soyadi.ToLower().Contains("o"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("o", "ö"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ö") || oyuncu.Kisi.Soyadi.ToLower().Contains("ö"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ö", "o"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("u") || oyuncu.Kisi.Soyadi.ToLower().Contains("u"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("u", "ü"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ü") || oyuncu.Kisi.Soyadi.ToLower().Contains("ü"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ü", "u"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("c") || oyuncu.Kisi.Soyadi.ToLower().Contains("c"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("c", "ç"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ç") || oyuncu.Kisi.Soyadi.ToLower().Contains("ç"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ç", "c"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("g") || oyuncu.Kisi.Soyadi.ToLower().Contains("g"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("g", "ğ"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ğ") || oyuncu.Kisi.Soyadi.ToLower().Contains("ğ"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ğ", "g"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("s") || oyuncu.Kisi.Soyadi.ToLower().Contains("s"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("s", "ş"));
        //            }

        //            if (oyuncu.Kisi.Adi.ToLower().Contains("ş") || oyuncu.Kisi.Soyadi.ToLower().Contains("ş"))
        //            {
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}-{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year}- {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} -{oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
        //                str.Add(($"{oyuncu.Kisi.DogumTarihi.Value.Year} - {oyuncu.Kisi.Adi.ToLower()} {oyuncu.Kisi.Soyadi.ToLower()}*").Replace("ş", "s"));
        //            }


        //            List<string> files = new List<string>();
        //            foreach (var item in str)
        //            {
        //                files.AddRange(Directory.EnumerateFiles(@"c:\\Resimler", item, SearchOption.AllDirectories));
        //            }

        //            List<OyuncuResim> resimler = new List<OyuncuResim>();
        //            foreach (var resim in files)
        //            {
        //                FileInfo fi = new FileInfo(resim);
        //                resimler.Add(new OyuncuResim
        //                {
        //                    OyuncuId = oyuncu.Id,
        //                    DosyaYolu = FileHelper.SaveFile(resim, "OyuncuResimleri"),
        //                    EklemeZamani = fi.CreationTime,
        //                    GuncellemeZamani = fi.CreationTime
        //                });
        //            }



        //            if (resimler.Count > 0)
        //            {
        //                oyuncu.Kisi.ProfilFotoUrl = resimler[0].DosyaYolu;
        //                await _OyuncuServis.UpdateAsync(oyuncu, _loginHelper.UserHelper);
        //                await _oyuncuResimServis.SaveListAsync(resimler, _loginHelper.UserHelper);
        //            }


        //        }
        //    }


        //    return View("Index");
        //}

        // GET: Oyuncus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Oyuncu = await _OyuncuServis.GetByIdAsync(id.Value);
            if (Oyuncu == null)
            {
                return NotFound();
            }

            return View(Oyuncu);
        }

        // POST: Oyuncus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _OyuncuServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OyuncuExistsAsync(int id)
        {
            Oyuncu entity = await _OyuncuServis.GetByIdAsync(id);
            return entity != null;
        }

        //private async Task<JsonResult> GetOyuncuGrid(OyuncuFilterDto filter)
        //{
        //    var oyuncular = await _OyuncuServis.GetListDtoAsync(i =>
        //           (filter.Adi == null || i.Kisi.Adi.StartsWith(filter.Adi)) &&
        //           (filter.Soyadi == null || i.Kisi.Soyadi.StartsWith(filter.Soyadi)) &&
        //           (filter.YasMin == 0 || i.Kisi.DogumTarihi >= DateTime.Today.AddYears(-1 * filter.YasMin)) &&
        //           (filter.YasMax == 0 || i.Kisi.DogumTarihi <= DateTime.Today.AddYears(-1 * filter.YasMax))
        //       );

        //    return Json(oyuncular);
        //}
        [AllowAnonymous]
        public async Task<JsonResult> GetOyuncuGrid(OyuncuFilterDto filter)
        {
            var oyuncular = await _OyuncuServis.GetGridAsync(filter);

            return Json(oyuncular);
            //return Json(oyuncular);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> GetOyuncuGrid()
        {
            int draw = Request.Query["draw"].ToInt(0);
            int start = Request.Query["start"].ToInt(0);
            int length = Request.Query["length"].ToInt(0);
            int pageSize = length;
            int skip = start.ToInt(0);

            var filter = new OyuncuFilterDto
            {
                Adi = Request.Query["adi"],
                Soyadi = Request.Query["soyadi"]
            };

            List<OyuncuListDto> oyuncular = await _OyuncuServis.GetListDtoAsync(i =>
                    (filter.TC == null || i.Kisi.TC.StartsWith(filter.TC)) &&
                   (filter.Adi == null || i.Kisi.Adi.StartsWith(filter.Adi)) &&
                   (filter.Soyadi == null || i.Kisi.Soyadi.StartsWith(filter.Soyadi)) &&
                   (filter.YasMin == 0 || i.Kisi.DogumTarihi <= DateTime.Today.AddYears(-1 * filter.YasMin)) &&
                   (filter.YasMaks == 0 || i.Kisi.DogumTarihi >= DateTime.Today.AddYears(-1 * filter.YasMaks)) &&
                   (filter.Cinsiyet == 0 || i.Kisi.Cinsiyet == (EnuCinsiyet)filter.Cinsiyet) &&
                   (filter.Uyruk == 0 || i.Kisi.UyrukId == filter.Uyruk) &&
                   (filter.KaseMin == 0 || i.Kase >= filter.KaseMin) &&
                   (filter.KaseMaks == 0 || i.Kase <= filter.KaseMaks) &&
                   (filter.BoyMin == 0 || i.Boy >= filter.BoyMin) &&
                   (filter.BoyMaks == 0 || i.Boy <= filter.BoyMaks) &&
                   (filter.KiloMin == 0 || i.Kilo >= filter.KiloMin) &&
                   (filter.KiloMaks == 0 || i.Kilo <= filter.KiloMaks) &&
                   (filter.AltBedenMin == 0 || i.AltBeden >= filter.AltBedenMin) &&
                   (filter.AltBedenMaks == 0 || i.AltBeden <= filter.AltBedenMaks) &&
                   (filter.UstBedenMin == 0 || i.UstBeden >= filter.UstBedenMin) &&
                   (filter.UstBedenMaks == 0 || i.UstBeden <= filter.UstBedenMaks) &&
                   (filter.AyakNumarasiMin == 0 || i.AyakNumarasi >= filter.AyakNumarasiMin) &&
                   (filter.AyakNumarasiMaks == 0 || i.AyakNumarasi <= filter.AyakNumarasiMaks) &&
                   (filter.GozRengi == 0 || i.GozRengi == (EnuGozRengi)filter.GozRengi) &&
                   (filter.TenRengi == 0 || i.TenRengi == (EnuTenRengi)filter.TenRengi) &&
                   (filter.SacRengi == 0 || i.SacRengi == (EnuSacRengi)filter.SacRengi) &&
                   i.Aktif == true && i.Kisi.Aktif == true
               );

            var data = oyuncular.Skip(skip).Take(pageSize).ToList();
            return Json(
                new
                {
                    draw = filter.Draw,
                    recordsFiltered = data.Count,
                    recordsTotal = oyuncular.Count,
                    data = oyuncular
                });
            //return Json(oyuncular);
        }



    }

}
