using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Helper
{
    public static class FileHelper
    {
        public static string _WebRootPath { get { return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"); } }

        public static string SaveFile(this IFormFile formFile, string yer)
        {
            if (formFile != null)
            {
                //string pic = Path.GetFileName(file.FileName);

                yer = string.Format("Resimler/{0}/{1}/{2}", DateTime.Now.Year, DateTime.Now.Month, yer);
                string path = Path.Combine(_WebRootPath, yer.Replace("/", "\\"));

                // file is uploaded
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                path = Path.Combine(path, dosyaAdi);
                formFile.CopyTo(new FileStream(path, FileMode.Create));

                return String.Format("/{0}/{1}", yer, dosyaAdi);
            }
            else
            {
                return null;
            }
        }

        public static string SaveFile(string kaynakyer, string tasinacakyer)
        {
            if (kaynakyer != null)
            {
                //string pic = Path.GetFileName(file.FileName);

                tasinacakyer = $"Dosyalar/{DateTime.Now.Year}/{DateTime.Now.Month}/Resimler/{tasinacakyer}";
                string path = Path.Combine(_WebRootPath, tasinacakyer.Replace("/", "\\"));

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
