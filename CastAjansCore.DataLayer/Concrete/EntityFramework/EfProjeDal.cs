using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calbay.Core.DataAccess;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class EfProjeDal : EfEntityRepositoryBase<Proje, CastAjansContext>, IProjeDal
    {
        public async Task<ProjeDetailDto> GetDetailByGuidIdAsync(string guidId)
        {
            using (var context = new CastAjansContext())
            {
                var a = context.Projeler
                    .Where(p => p.GuidId.Equals(guidId))
                    .Include(k => k.ProjeKarakterleri)
                    .Select(p => new ProjeDetailDto
                    {
                        Id = p.Id,
                        ProjeAdi = p.Adi,
                        ProjeTarihBas = p.TarihBas,
                        ProjeTarihBit = p.TarihBit,
                        IlgiliKisi = $"{p.IsiTakipEden.Kisi.Adi} {p.IsiTakipEden.Kisi.Soyadi}",
                        IlgiliTelefon = p.IsiTakipEden.Kisi.Telefon,
                        IlgiliEPosta = p.IsiTakipEden.Kisi.EPosta,
                        ProjeKarakterleri = p.ProjeKarakterleri
                                            .Where(k => k.Aktif)
                                            .Select(k => new ProjeKarakterDetailDto
                                            {
                                                Id = k.Id,
                                                Adi = k.Adi,
                                                KarakterSayisi = k.KarakterSayisi,
                                                Oyuncular = k.ProjeKarakterOyunculari
                                                            .Where(o => o.Aktif)
                                                            .Select(o => new OyuncuDetailDto
                                                            {
                                                                Id = o.OyuncuId,
                                                                Adi = o.Oyuncu.Kisi.Adi,
                                                                Soyadi = o.Oyuncu.Kisi.Soyadi,
                                                                AltBeden = o.Oyuncu.AltBeden,
                                                                UstBeden = o.Oyuncu.UstBeden,
                                                                AyakNumarasi = o.Oyuncu.AyakNumarasi,
                                                                Boy = o.Oyuncu.Boy,
                                                                Kilo = o.Oyuncu.Kilo,
                                                                GozRengi = o.Oyuncu.GozRengi,
                                                                SacRengi = o.Oyuncu.SacRengi,
                                                                TenRengi = o.Oyuncu.TenRengi,
                                                                OyuculukEgitimi = o.Oyuncu.OyuculukEgitimi,
                                                                Tecrubeler = o.Oyuncu.Tecrubeler,
                                                                YabanciDil = o.Oyuncu.YabanciDil,
                                                                Yetenekleri = o.Oyuncu.Yetenekleri,
                                                                OyuncuResimleri = o.Oyuncu.OyuncuResimleri
                                                                                    .Where(r => r.Aktif)
                                                                                    .OrderByDescending(r => r.EklemeZamani)
                                                                                    .Select(r => r.DosyaYolu)
                                                                                    .Take(3)
                                                                                    .ToList()
                                                            }).ToList()
                                            }).ToList()
                    });
                //var sql=a.
                return await a.FirstOrDefaultAsync();
            }
        }

        //public class Project
        //{
        //    public int Id { get; set; }

        //    public int Name { get; set; }

        //    public IList<User> Users { get; set; }
        //}

        //public class User
        //{
        //    public int Id { get; set; }

        //    public int Name { get; set; }

        //    public IList<UserPhoto> UserPhotos { get; set; }
        //}

        //public class UserPhoto
        //{
        //    public int Id { get; set; }

        //    public string FilePath { get; set; }
        //}

        //public class Product
        //{
        //    public int Id { get; set; }
        //    public string Adi { get; set; }
        //}



    }
}
