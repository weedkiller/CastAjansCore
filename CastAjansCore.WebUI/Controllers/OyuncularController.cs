using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using CastAjansCore.WebUI.Helper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    [Authorize(Roles = "admin,calisan")]
    public class OyuncularController : Controller
    {
        private readonly IOyuncuServis _OyuncuServis;
        private readonly LoginHelper _loginHelper;

        //private readonly IHostingEnvironment _HostingEnvironment;
        public OyuncularController(IOyuncuServis OyuncuServis, LoginHelper loginHelper)
        {
            _OyuncuServis = OyuncuServis;
            //_HostingEnvironment = environment;
            _loginHelper = loginHelper;
            ViewData["UserHelper"] = _loginHelper.UserHelper;
        }

        public async Task<IActionResult> Index()
        {
            
            var Oyuncular = await _OyuncuServis.GetListDtoAsync();
            return View(Oyuncular);
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
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Id");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.IlId");
                ModelState.Remove("KisiEditDto.Kisi.Ilce.Adi");

                if (ModelState.IsValid)
                {
                    try
                    {
                        Oyuncu Oyuncu = oyuncuEditDto.Oyuncu;
                        Oyuncu.Kisi = oyuncuEditDto.KisiEditDto.Kisi;
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

        private JsonResult GetOyuncuGrid(OyuncuFilterDto filter)
        {
            var oyuncular = _OyuncuServis.GetList(i =>
                   (filter.Adi == null || i.Kisi.Adi.StartsWith(filter.Adi)) &&
                   (filter.Soyadi == null || i.Kisi.Soyadi.StartsWith(filter.Soyadi)) &&
                   (filter.YasMin == 0 || i.Kisi.DogumTarihi >= DateTime.Today.AddYears(-1 * filter.YasMin)) &&
                   (filter.YasMax == 0 || i.Kisi.DogumTarihi <= DateTime.Today.AddYears(-1 * filter.YasMax))
               );

            return Json(oyuncular);
        }

        public IActionResult ExcelImport()
        {
            return View(new ExcelImport());
        }
        [HttpPost]
        public IActionResult ExcelImport(ExcelImport dto)
        {
            using (Stream inputStream = dto.file.OpenReadStream())
            {
                DataTable dt = inputStream.ReadExcel();
                //DataTable dt = GetDataTableFromSpreadsheet(inputStream, false);
            }


            return View();
        }

        //public static DataTable GetDataTableFromSpreadsheet(Stream MyExcelStream, bool ReadOnly)
        //{
        //    DataTable dt = MyExcelStream
        //    using (SpreadsheetDocument sDoc = SpreadsheetDocument.Open(MyExcelStream, ReadOnly))
        //    {
        //        WorkbookPart workbookPart = sDoc.WorkbookPart;
        //        IEnumerable<Sheet> sheets = sDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
        //        string relationshipId = sheets.First().Id.Value;
        //        WorksheetPart worksheetPart = (WorksheetPart)sDoc.WorkbookPart.GetPartById(relationshipId);
        //        Worksheet workSheet = worksheetPart.Worksheet;
        //        SheetData sheetData = workSheet.GetFirstChild<SheetData>();
        //        IEnumerable<Row> rows = sheetData.Descendants<Row>();

        //        foreach (Cell cell in rows.ElementAt(0))
        //        {
        //            dt.Columns.Add(GetCellValue(sDoc, cell));
        //        }

        //        foreach (Row row in rows) //this will also include your header row...
        //        {
        //            DataRow tempRow = dt.NewRow();

        //            for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
        //            {
        //                tempRow[i] = GetCellValue(sDoc, row.Descendants<Cell>().ElementAt(i));
        //            }

        //            dt.Rows.Add(tempRow);
        //        }
        //    }
        //    dt.Rows.RemoveAt(0);
        //    return dt;
        //}
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }
        public static string ConvertDataTableToHTMLTable(DataTable dt)
        {
            string ret = "";
            ret = "<table id=" + (char)34 + "tblExcel" + (char)34 + ">";
            ret += "<tr>";
            foreach (DataColumn col in dt.Columns)
            {
                ret += "<td class=" + (char)34 + "tdColumnHeader" + (char)34 + ">" + col.ColumnName + "</td>";
            }
            ret += "</tr>";
            foreach (DataRow row in dt.Rows)
            {
                ret += "<tr>";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ret += "<td class=" + (char)34 + "tdCellData" + (char)34 + ">" + row[i].ToString() + "</td>";
                }
                ret += "</tr>";
            }
            ret += "</table>";
            return ret;
        }
    }

}
