using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin,calisan")]
    public class ProjelerController : Controller
    {
        private readonly IProjeServis _ProjeServis;
        private readonly IMusteriServis _MusteriServis;
        private readonly IKullaniciServis _KullaniciServis;
        private readonly IProjeKarakterServis _ProjeKarakterServis;
        private readonly IProjeKarakterOyuncuServis _ProjeKarakterOyuncuServis;
        private readonly IUyrukServis _UyrukServis;
        private readonly IEmailServis _emailServis;
        private readonly LoginHelper _loginHelper;

        public ProjelerController(IProjeServis ProjeServis,
            IMusteriServis musteriServis,
            IKullaniciServis kullaniciServis,
            IProjeKarakterServis projeKarakterServis,
            IProjeKarakterOyuncuServis projeKarakterOyuncuServis,
            IUyrukServis uyrukServis,
            IEmailServis emailServis,
            LoginHelper loginHelper)
        {
            _ProjeServis = ProjeServis;
            _MusteriServis = musteriServis;
            _KullaniciServis = kullaniciServis;
            _ProjeKarakterServis = projeKarakterServis;
            _ProjeKarakterOyuncuServis = projeKarakterOyuncuServis;
            _UyrukServis = uyrukServis;
            _emailServis = emailServis;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        public async Task<IActionResult> Index(int? id)
        {

            ProjeListDto ProjeListDto = new ProjeListDto();
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => (id == null || i.MusteriId == id) && i.Aktif == true);
            if (id != null)
            {
                ProjeListDto.Musteri = await _MusteriServis.GetByIdAsync(id.Value); ;
            }

            ProjeListDto.Projeler = await tProje;

            return View(ProjeListDto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);
            //_ProjeServis.Pdf();
            return View(model);
        }

        //public ViewAsPdf Pdf(string id)
        //{
        //    ViewAsPdf pdf = new ViewAsPdf("Detail", id)
        //    {
        //        FileName = "File.pdf",
        //        PageSize = Rotativa.Options.Size.A4,
        //        PageMargins = { Left = 0, Right = 0 }
        //    };

        //    return pdf;
        //}

        public async Task<IActionResult> Edit(int? id, int musteriId)
        {
            ProjeEditDto projeEditDto = await _ProjeServis.GetEditDtoAsync(id, musteriId);
            if (projeEditDto.Proje.GuidId == Guid.Empty)
            {
                projeEditDto.Proje.GuidId = Guid.NewGuid();
            }
            if (projeEditDto.Proje == null)
            {
                return NotFound();
            }
            if (projeEditDto.Proje.IsiTakipEdenId == 0)
            {
                projeEditDto.Proje.IsiTakipEdenId = _loginHelper.UserHelper.Id;
            }
            return View(projeEditDto);
        }

        private async Task Save(int? id, Proje Proje)
        {
            if (id == null || id == 0)
            {
                await _ProjeServis.AddAsync(Proje, _loginHelper.UserHelper);
            }
            else
            {
                await _ProjeServis.UpdateAsync(Proje, _loginHelper.UserHelper);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Proje Proje)
        {
            if (ModelState.IsValid)
            {
                await Save(id, Proje);
                return RedirectToAction(nameof(Index), new { id = Proje.MusteriId });
            }
            return View(Proje);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndDetail(int? id, Proje Proje)
        {
            await Save(id, Proje);
            return RedirectToAction(nameof(Detail), new { id = Proje.GuidId });
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Proje = await _ProjeServis.GetByIdAsync(id.Value);
            if (Proje == null)
            {
                return NotFound();
            }

            return View(Proje);
        }

        // POST: Projes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ProjeServis.DeleteAsync(id, _loginHelper.UserHelper);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProjeExistsAsync(int id)
        {
            Proje entity = await _ProjeServis.GetByIdAsync(id);
            return entity != null;
        }

        [AllowAnonymous]
        public async Task<FileResult> Zip(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);
            List<InMemoryFile> files = new List<InMemoryFile>();
            foreach (var karakter in model.ProjeKarakterleri)
            {
                foreach (var oyuncu in karakter.Oyuncular)
                {
                    foreach (var resim in oyuncu.OyuncuResimleri)
                    {
                        string dosyaYeri = FileHelper._WebRootPath + resim.Replace("/", "\\");
                        if (System.IO.File.Exists(dosyaYeri))
                        {
                            string filename = $"{oyuncu.Adi} {oyuncu.Soyadi}_{oyuncu.OyuncuResimleri.IndexOf(resim) + 1}{Path.GetExtension(resim)}";

                            InMemoryFile file = new InMemoryFile
                            {
                                FileName = filename,
                                Content = System.IO.File.ReadAllBytes(dosyaYeri)
                            };
                            files.Add(file);
                        }
                    }
                }
            }
            return File(GetZipArchive(files), System.Net.Mime.MediaTypeNames.Application.Zip, "test.zip");
        }

        private static byte[] GetZipArchive(List<InMemoryFile> files)
        {
            byte[] archiveFile;
            using (var archiveStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    {
                        var zipArchiveEntry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open())
                            zipStream.Write(file.Content, 0, file.Content.Length);
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }

        public class InMemoryFile
        {
            public string FileName { get; set; }
            public byte[] Content { get; set; }
        }

        public async Task<IActionResult> MailGonder(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

            StringBuilder sb = new StringBuilder(FileHelper.ReadFile("\\MailTema\\ProjeTeklif.html"));
            sb.Replace("{ProjeAdi}", model.ProjeAdi);
            sb.Replace("{Ilgili}", model.IlgiliKisi);
            sb.Replace("{IlgiliTelefon}", model.IlgiliTelefon + " - " + model.IlgiliCep);
            sb.Replace("{IlgiliEPosta}", model.IlgiliEPosta);
            sb.Replace("{SunumLink}", $"{Request.Scheme}://{Request.Host}{Request.PathBase}/Projeler/Detail/{id}");

            _emailServis.SendEmail(model.EPostaAdresleri, $"Life Ajans {model.ProjeAdi} sunum.", sb.ToString(), model.IlgiliEPosta);

            MesajHelper.MesajEkle(ViewBag, "E-Posta gönderildi.");
            return RedirectToAction(nameof(Detail), new { id });
        }

    }
}