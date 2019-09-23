using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Calbay.Core.DataAccess;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class EfOyuncuDal : EfEntityRepositoryBase<Oyuncu, CastAjansContext>, IOyuncuDal
    {
        public async Task<GridDto<OyuncuListDto>> GetGridAsync(int start, int pageSize, Expression<Func<Oyuncu, bool>> filter = null)
        {
            GridDto<OyuncuListDto> gridDto = new GridDto<OyuncuListDto>();
            using (var context = new CastAjansContext())
            {
                var query = (filter == null
                    ? context.Oyuncular
                    : context.Oyuncular.Where(filter));

                query = query.Include(i => i.Kisi);
                query = query.Include(i => i.Kisi.Uyruk);
                query = query.Include(i => i.OyuncuResimleri);

                var data = query.Select(i =>
                    new OyuncuListDto
                    {
                        Id = i.Id,
                        Adi = i.Kisi.Adi,
                        Soyadi = i.Kisi.Soyadi,
                        AltBeden = i.AltBeden,
                        Boy = i.Boy,
                        Cinsiyet = i.Kisi.Cinsiyet.ToDisplay(),
                        DogumTarihi = i.Kisi.DogumTarihi,
                        GozRengi = i.GozRengi.ToDisplay(),
                        Kase = i.Kase,
                        Kilo = i.Kilo,
                        ProfilFotoUrl = i.Kisi.ProfilFotoUrl,
                        SacRengi = i.SacRengi.ToDisplay(),
                        TenRengi = i.TenRengi.ToDisplay(),
                        UstBeden = i.UstBeden,
                        Uyruk = i.Kisi.Uyruk.Adi,
                        GuncellemeTarihi = i.GuncellemeZamani
                    }
                    ).OrderByDescending(i => i.GuncellemeTarihi);


                gridDto.RecordsFiltered = data.Count();
                gridDto.Data = await data.Skip(start).Take(pageSize).ToListAsync<OyuncuListDto>();
                gridDto.RecordsTotal = gridDto.Data.Count;

                foreach (var item in gridDto.Data)
                {
                    item.Projeler = (from proje in context.Projeler
                                     join pkararakter in context.ProjeKarakterleri on proje.Id equals pkararakter.ProjeId
                                     join projeOyuncu in context.ProjeKarakterOyunculari on pkararakter.Id equals projeOyuncu.ProjeKarakterId
                                     where projeOyuncu.OyuncuId == item.Id && 
                                            proje.TarihBas >= DateTime.Today && 
                                            projeOyuncu.Aktif && 
                                            pkararakter.Aktif && 
                                            proje.Aktif
                                     select proje).ToList();
                }
            }

            return gridDto;
        }

        public override async Task<List<Oyuncu>> GetListAsync(Expression<Func<Oyuncu, bool>> filter = null)
        {
            using (var context = new CastAjansContext())
            {
                var query = (filter == null
                    ? context.Oyuncular
                    : context.Oyuncular.Where(filter));

                query = query.Include(i => i.Kisi);
                query = query.Include(i => i.Kisi.Uyruk);
                query = query.Include(i => i.OyuncuResimleri);

                return await query.ToListAsync<Oyuncu>();
            }
        }
    }
}
