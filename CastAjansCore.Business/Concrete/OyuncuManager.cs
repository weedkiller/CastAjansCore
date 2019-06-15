using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuManager : ManagerRepositoryBase<Oyuncu>, IOyuncuServis
    {
        private readonly IKisiServis _kisiServis;
        private readonly IOyuncuResimServis _OyuncuResimServis;
        private readonly IOyuncuVideoServis _OyuncuVideoServis;
        public OyuncuManager(IOyuncuDal dal, IKisiServis kisiServis, IOyuncuResimServis oyuncuResimServis, IOyuncuVideoServis oyuncuVideoServis) : base(dal)
        {
            _kisiServis = kisiServis;
            _OyuncuResimServis = oyuncuResimServis;
            _OyuncuVideoServis = oyuncuVideoServis;
        }

        public async Task<OyuncuEditDto> GetEditDtoAsync(int? id)
        {
            OyuncuEditDto OyuncuEditDto = new OyuncuEditDto();
            Task<KisiEditDto> tKisiEditDto = _kisiServis.GetEditDtoAsync(id);

            if (id == null)
            {
                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
            }
            else
            {
                Task<Oyuncu> tOyuncu = base.GetByIdAsync(id.Value);
                Task<List<OyuncuResim>> tOyuncuResimleri = _OyuncuResimServis.GetListByOyuncuIdAsync(id.Value);
                Task<List<OyuncuVideo>> tOyuncuVideolari = _OyuncuVideoServis.GetListByOyuncuIdAsync(id.Value);

                OyuncuEditDto.Oyuncu = await tOyuncu;
                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
                OyuncuEditDto.OyuncuResimleri = await tOyuncuResimleri;
                OyuncuEditDto.OyuncuVideolari = await tOyuncuVideolari;
            }

            return OyuncuEditDto;
        }


        public async Task<List<OyuncuListDto>> GetListDtoAsync(Expression<Func<Oyuncu, bool>> filter = null)
        {
            List<OyuncuListDto> listDto = new List<OyuncuListDto>();
            var oyuncular = await base._dal.GetListAsync(filter);

            foreach (var item in oyuncular)
            {
                listDto.Add(new OyuncuListDto
                {
                    Id = item.Id,
                    Adi = item.Kisi.Adi,
                    Soyadi = item.Kisi.Soyadi,
                    DogumTarihi = item.Kisi.DogumTarihi,
                    ProfilUrl = (
                                    (OyuncuResim)(item.OyuncuResimleri
                                                    .Where(i => i.Default == true && i.Aktif == true)
                                                    .FirstOrDefault()
                                                    .IfIsNull(new OyuncuResim())
                                                )
                                ).DosyaYolu
                }
                );
            }

            return listDto;
        }

        public override async Task AddAsync(Oyuncu entity, UserHelper userHelper)
        {
            await _kisiServis.AddAsync(entity.Kisi, userHelper);
            Task[] tasks = new Task[3];

            entity.Id = entity.Kisi.Id;
            tasks[0] = base.AddAsync(entity, userHelper);

            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[1] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri, userHelper);

            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari, userHelper);

            await Task.WhenAll(tasks);
        }

        public override async Task UpdateAsync(Oyuncu entity, UserHelper userHelper)
        {
            Task[] tasks = new Task[4];
            tasks[0] = _kisiServis.UpdateAsync(entity.Kisi, userHelper);
            tasks[1] = base.UpdateAsync(entity, userHelper);

            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri, userHelper);

            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[3] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari, userHelper);

            await Task.WhenAll(tasks);
        }
    }
}
