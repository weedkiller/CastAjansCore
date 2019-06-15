using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Calbay.Core.Helper;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Hosting;

namespace CastAjansCore.WebUI.Controllers
{
    public class OyuncularController : Controller
    {
        private readonly IOyuncuServis _OyuncuServis;
        //private readonly IHostingEnvironment _HostingEnvironment;
        public OyuncularController(IOyuncuServis OyuncuServis)
        {
            _OyuncuServis = OyuncuServis;
            //_HostingEnvironment = environment;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var Oyuncular = await _OyuncuServis.GetListDtoAsync();
            return View(Oyuncular);
        }

        // GET: Oyuncus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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
                            foreach (var item in oyuncuEditDto.OyuncuResimleriFile)
                            {
                                oyuncuEditDto.OyuncuResimleri.Add(
                                    new OyuncuResim { DosyaYolu = item.SaveFile("OyuncuResimleri") }
                                    );
                            }
                        }

                        if (oyuncuEditDto.OyuncuVideolariFile != null && oyuncuEditDto.OyuncuVideolariFile.Count > 0)
                        {
                            foreach (var item in oyuncuEditDto.OyuncuVideolariFile)
                            {
                                oyuncuEditDto.OyuncuResimleri.Add(
                                    new OyuncuResim { DosyaYolu = item.SaveFile("OyuncuResimleri") }
                                    );
                            }

                            if (id == null)
                            {
                                await _OyuncuServis.AddAsync(Oyuncu, HttpContext.Session.GetUserHelper());
                            }
                            else
                            {
                                if (id != Oyuncu.Id)
                                {
                                    return NotFound();
                                }
                                await _OyuncuServis.UpdateAsync(Oyuncu, HttpContext.Session.GetUserHelper());
                            }
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
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var combolar = await _OyuncuServis.GetEditDtoAsync(id);
            oyuncuEditDto.KisiEditDto.Ilceler = combolar.KisiEditDto.Ilceler;
            oyuncuEditDto.KisiEditDto.Iller = combolar.KisiEditDto.Iller;
            oyuncuEditDto.KisiEditDto.Uyruklar = combolar.KisiEditDto.Uyruklar;
            return View(oyuncuEditDto);
        }

        // GET: Oyuncus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
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
            await _OyuncuServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> OyuncuExistsAsync(int id)
        {
            Oyuncu entity = await _OyuncuServis.GetByIdAsync(id);
            return entity != null;
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
