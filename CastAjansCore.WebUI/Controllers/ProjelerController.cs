using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Filters;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin,calisan")]
    [RequestFormSizeLimit(valueCountLimit: 10000)]
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

            ProjeListDto.Projeler = (await tProje).OrderByDescending(i => i.TarihBas).ToList();

            return View(ProjeListDto);
        }

        public async Task<IActionResult> Projelerim()
        {

            ProjeListDto ProjeListDto = new ProjeListDto();
            Task<List<Proje>> tProje = _ProjeServis.GetListAsync(i => i.IsiTakipEdenId == _loginHelper.UserHelper.Id && i.Aktif == true);

            ProjeListDto.Projeler = (await tProje).OrderByDescending(i => i.TarihBas).ToList();

            return View("Index", ProjeListDto);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detail(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);
            //_ProjeServis.Pdf();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndCastList(int? id, Proje Proje)
        {
            await Save(id, Proje);
            return RedirectToAction(nameof(CastList), new { id = Proje.GuidId });
        }

        public async Task<IActionResult> CastList(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

            //_ProjeServis.Pdf();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndExcelList(int? id, Proje Proje)
        {
            await Save(id, Proje);
            return RedirectToAction(nameof(ExcelList), new { id = Proje.GuidId });
        }

        //public async Task<IActionResult> ExcelList(string id)
        //{
        //    ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

        //    byte[] fileContents;

        //    using (var package = new ExcelPackage())
        //    {
        //        var worksheet = package.Workbook.Worksheets.Add("Sheet1");

        //        // Put whatever you want here in the sheet
        //        // For example, for cell on row1 col1
        //        worksheet.Cells[1, 1].Value = "Sıra";
        //        worksheet.Cells[1, 1].Style.Font.Size = 12;
        //        worksheet.Cells[1, 1].Style.Font.Bold = true;
        //        worksheet.Cells[1, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //        worksheet.Cells[1, 2].Value = "Ad";
        //        worksheet.Cells[1, 2].Style.Font.Size = 12;
        //        worksheet.Cells[1, 2].Style.Font.Bold = true;
        //        worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //        worksheet.Cells[1, 3].Value = "Soyad";
        //        worksheet.Cells[1, 3].Style.Font.Size = 12;
        //        worksheet.Cells[1, 3].Style.Font.Bold = true;
        //        worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //        worksheet.Cells[1, 4].Value = "TC";
        //        worksheet.Cells[1, 4].Style.Font.Size = 12;
        //        worksheet.Cells[1, 4].Style.Font.Bold = true;
        //        worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;
        //        int count = 1;
        //        foreach (var karakter in model.ProjeKarakterleri)
        //        {
        //            foreach (var oyuncu in karakter.Oyuncular)
        //            {
        //                if (oyuncu.KarakterDurumu == EnuKarakterDurumu.KabulEdildi || oyuncu.KarakterDurumu == EnuKarakterDurumu.Oynadi)
        //                {
        //                    count++;

        //                    worksheet.Cells[count, 1].Value = count - 1;
        //                    worksheet.Cells[count, 1].Style.Font.Size = 12;
        //                    worksheet.Cells[count, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //                    worksheet.Cells[count, 2].Value = oyuncu.Adi;
        //                    worksheet.Cells[count, 2].Style.Font.Size = 12;
        //                    worksheet.Cells[count, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //                    worksheet.Cells[count, 3].Value = oyuncu.Soyadi;
        //                    worksheet.Cells[count, 3].Style.Font.Size = 12;
        //                    worksheet.Cells[count, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

        //                    worksheet.Cells[count, 4].Value = oyuncu.Tc;
        //                    worksheet.Cells[count, 4].Style.Font.Size = 12;
        //                    worksheet.Cells[count, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;
        //                }
        //            }
        //        }

        //        // So many things you can try but you got the idea.

        //        // Finally when you're done, export it to byte array.
        //        fileContents = package.GetAsByteArray();
        //    }

        //    if (fileContents == null || fileContents.Length == 0)
        //    {
        //        return NotFound();
        //    }

        //    return File(
        //        fileContents: fileContents,
        //        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //        fileDownloadName: "CastList.xlsx"
        //    );
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAndList(int? id, Proje Proje)
        {
            await Save(id, Proje);
            return RedirectToAction(nameof(CastList), new { id = Proje.GuidId });
        }

        public async Task<IActionResult> List(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

            //_ProjeServis.Pdf();
            return View(model);
        }

        [AllowAnonymous]
        public async Task<string> OyuncuSec(string projeGuid, int karakterId, int oyuncuId, int durum)
        {

            await _ProjeKarakterServis.UpdateDurumuAsync(projeGuid, karakterId, oyuncuId, (EnuKarakterDurumu)durum, new UserHelper { Id = 0 });

            //_ProjeServis.Pdf();
            return "OK";
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
            if (Proje.ProjeKarakterleri.IsNotNull())
            {
                for (int i = Proje.ProjeKarakterleri.Count - 1; i >= 0; i--)
                {
                    if (Proje.ProjeKarakterleri[i].ProjeKarakterOyunculari.IsNull() || Proje.ProjeKarakterleri[i].ProjeKarakterOyunculari.Count == 0)
                    {
                        Proje.ProjeKarakterleri.Remove(Proje.ProjeKarakterleri[i]);
                    }
                    else
                    {
                        for (int oyuncuIndex = 0; oyuncuIndex < Proje.ProjeKarakterleri[i].ProjeKarakterOyunculari.Count; oyuncuIndex++)
                        {
                            ModelState.Remove($"Proje.ProjeKarakterleri[{i}].ProjeKarakterOyunculari[{oyuncuIndex}].Oyuncu.Kisi.Adi");
                            ModelState.Remove($"Proje.ProjeKarakterleri[{i}].ProjeKarakterOyunculari[{oyuncuIndex}].Oyuncu.Kisi.Soyadi");
                        }
                    }

                }
            }
            if (ModelState.IsValid)
            {
                await Save(id, Proje);
                return RedirectToAction(nameof(Index), new { id = Proje.MusteriId });
            }
            else
            {
                ProjeEditDto projeEditDto = await _ProjeServis.GetEditDtoAsync(id, Proje.MusteriId);
                projeEditDto.Proje = Proje;
                return View(projeEditDto);
            }

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
            return File(GetZipArchive(files), System.Net.Mime.MediaTypeNames.Application.Zip, $"{model.ProjeAdi.Replace(" ", "")}.zip");
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
                        var zipArchiveEntry = archive.CreateEntry(file.FileName, System.IO.Compression.CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open())
                            zipStream.Write(file.Content, 0, file.Content.Length);
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }

        public async Task<FileResult> KimliklerDosya(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);
            List<InMemoryFile> files = new List<InMemoryFile>();
            foreach (var karakter in model.ProjeKarakterleri)
            {
                foreach (var oyuncu in karakter.Oyuncular)
                {
                    if (oyuncu.KarakterDurumu == EnuKarakterDurumu.KabulEdildi)
                    {

                        if (oyuncu.KimlikOn.IsNotNull())
                        {
                            string dosyaYeri = FileHelper._WebRootPath + oyuncu.KimlikOn.Replace("/", "\\");
                            if (System.IO.File.Exists(dosyaYeri))
                            {
                                string filename = $"{oyuncu.Adi} {oyuncu.Soyadi}_{oyuncu.Tc}_On{Path.GetExtension(oyuncu.KimlikOn)}";

                                InMemoryFile file = new InMemoryFile
                                {
                                    FileName = filename,
                                    Content = System.IO.File.ReadAllBytes(dosyaYeri)
                                };
                                files.Add(file);
                            }
                            dosyaYeri = FileHelper._WebRootPath + oyuncu.KimlikArka.Replace("/", "\\");
                            if (System.IO.File.Exists(dosyaYeri))
                            {
                                string filename = $"{oyuncu.Adi} {oyuncu.Soyadi}_{oyuncu.Tc}_Arka{Path.GetExtension(oyuncu.KimlikArka)}";

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
            }
            return File(GetZipArchive(files), System.Net.Mime.MediaTypeNames.Application.Zip, $"{model.ProjeAdi.Replace(" ", "")}.zip");
        }

        public async Task<IActionResult> ExcelList(string id)
        {
            ProjeDetailDto model = await _ProjeServis.GetDetailAsync(id);

            byte[] fileContents;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Put whatever you want here in the sheet
                // For example, for cell on row1 col1
                worksheet.Cells[1, 1].Value = "Sıra";
                worksheet.Cells[1, 1].Style.Font.Size = 12;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(1).Width = 6;

                worksheet.Cells[1, 2].Value = "Ad";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(2).Width = 25;

                worksheet.Cells[1, 3].Value = "Soyad";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(3).Width = 25;

                worksheet.Cells[1, 4].Value = "TC";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(4).Width = 18;

                worksheet.Cells[1, 5].Value = "D.Tarihi";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(5).Width = 18;

                worksheet.Cells[1, 6].Value = "Telefon";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(6).Width = 20;

                worksheet.Cells[1, 7].Value = "İl";
                worksheet.Cells[1, 7].Style.Font.Size = 12;
                worksheet.Cells[1, 7].Style.Font.Bold = true;
                worksheet.Column(7).Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(7).Width = 20;

                worksheet.Cells[1, 8].Value = "İlce";
                worksheet.Cells[1, 8].Style.Font.Size = 12;
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Column(8).Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(8).Width = 20;

                worksheet.Cells[1, 9].Value = "Adres";
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                worksheet.Column(9).Width = 60;
                int count = 1;

                foreach (var karakter in model.ProjeKarakterleri)
                {
                    foreach (var oyuncu in karakter.Oyuncular)
                    {
                        if (oyuncu.KarakterDurumu == EnuKarakterDurumu.KabulEdildi || oyuncu.KarakterDurumu == EnuKarakterDurumu.Oynadi)
                        {
                            count++;

                            worksheet.Cells[count, 1].Value = count - 1;
                            worksheet.Cells[count, 1].Style.Font.Size = 12;
                            worksheet.Cells[count, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 2].Value = oyuncu.Adi;
                            worksheet.Cells[count, 2].Style.Font.Size = 12;
                            worksheet.Cells[count, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 3].Value = oyuncu.Soyadi;
                            worksheet.Cells[count, 3].Style.Font.Size = 12;
                            worksheet.Cells[count, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 4].Value = oyuncu.Tc;
                            worksheet.Cells[count, 4].Style.Font.Size = 12;
                            worksheet.Cells[count, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells[count, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 5].Value = oyuncu.DogumTarihi;
                            worksheet.Cells[count, 5].Style.Numberformat.Format = "dd-MM-yyyy";
                            worksheet.Cells[count, 5].Style.Font.Size = 12;
                            worksheet.Cells[count, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            worksheet.Cells[count, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 6].Value = oyuncu.Cep ?? oyuncu.Telefon;
                            worksheet.Cells[count, 6].Style.Font.Size = 12;
                            worksheet.Cells[count, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 7].Value = oyuncu.Il;
                            worksheet.Cells[count, 7].Style.Font.Size = 12;
                            worksheet.Cells[count, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 8].Value = oyuncu.Ilce;
                            worksheet.Cells[count, 8].Style.Font.Size = 12;
                            worksheet.Cells[count, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                            worksheet.Cells[count, 9].Value = oyuncu.Adres;
                            worksheet.Cells[count, 9].Style.Font.Size = 12;
                            worksheet.Cells[count, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                        }
                    }
                }

                // So many things you can try but you got the idea.

                // Finally when you're done, export it to byte array.
                fileContents = package.GetAsByteArray();
            }

            if (fileContents == null || fileContents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: fileContents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: $"{model.MusteriAdi}-{model.ProjeAdi}-CastList.xlsx"
            );
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