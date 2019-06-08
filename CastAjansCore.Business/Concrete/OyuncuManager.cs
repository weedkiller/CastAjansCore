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
        public OyuncuManager(IOyuncuDal dal, IKisiServis kisiServis) : base(dal)
        {
            _kisiServis = kisiServis;
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

                OyuncuEditDto.Oyuncu = await tOyuncu;
                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
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

        public override async Task AddAsync(Oyuncu entity)
        {
            await _kisiServis.AddAsync(entity.Kisi);
            await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(Oyuncu entity)
        {
            Task[] tasks = new Task[2];
            tasks[0] = _kisiServis.UpdateAsync(entity.Kisi);
            tasks[1] = base.UpdateAsync(entity);

            await Task.WhenAll(tasks);
        }
    }
}
