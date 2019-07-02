using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

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
                OyuncuEditDto.Oyuncu = new Oyuncu();
            }
            else
            {
                Task<Oyuncu> tOyuncu = base.GetByIdAsync(id.Value);
                Task<List<OyuncuResim>> tOyuncuResimleri = _OyuncuResimServis.GetListByOyuncuIdAsync(id.Value);
                Task<List<OyuncuVideo>> tOyuncuVideolari = _OyuncuVideoServis.GetListByOyuncuIdAsync(id.Value);

                OyuncuEditDto.Oyuncu = await tOyuncu;
                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
                OyuncuEditDto.Oyuncu.OyuncuResimleri = await tOyuncuResimleri;
                OyuncuEditDto.Oyuncu.OyuncuVideolari = await tOyuncuVideolari;
            }

            return OyuncuEditDto;
        }

        public override async Task<Oyuncu> GetByIdAsync(int id)
        {
            return await _dal.GetAsync(new List<string> { "Kisi" }, i => i.Id == id && i.Aktif == true);
        }

        public override async Task DeleteAsync(int id, UserHelper userHelper)
        {
            var tKisi = _kisiServis.DeleteAsync(id, userHelper);
            var tOyuncu = base.DeleteAsync(id, userHelper);
            await Task.WhenAll(tKisi, tOyuncu);
        }

        public async Task<List<OyuncuListDto>> GetListDtoAsync(Expression<Func<Oyuncu, bool>> filter = null)
        {
            List<OyuncuListDto> listDto = new List<OyuncuListDto>();
            var oyuncular = await base._dal.GetListAsync(new List<string> { "Kisi", "Kisi.Uyruk", "OyuncuResimleri", }, filter);

            foreach (var item in oyuncular)
            {
                listDto.Add(new OyuncuListDto
                {
                    Id = item.Id,
                    Adi = item.Kisi.Adi,
                    Soyadi = item.Kisi.Soyadi,
                    DogumTarihi = item.Kisi.DogumTarihi,
                    ProfilFotoUrl = item.Kisi.ProfilFotoUrl,
                    Kase = item.Kase,
                    Uyruk = item.Kisi.Uyruk.Adi,
                    Cinsiyet = item.Kisi.Cinsiyet.ToDisplay(),
                    Boy = item.Boy,
                    Kilo = item.Kilo,
                    AltBeden = item.AltBeden,
                    UstBeden = item.UstBeden,
                    GozRengi = item.GozRengi.ToDisplay(),
                    TenRengi = item.TenRengi.ToDisplay(),
                    SacRengi = item.SacRengi.ToDisplay(),

                }
                );
            }

            return listDto;
        }

        public override async Task AddAsync(Oyuncu entity, UserHelper userHelper)
        {
            if (entity.Kisi.ProfilFotoUrl == null)
            {
                if (entity.OyuncuResimleri.Count > 0)
                {
                    entity.Kisi.ProfilFotoUrl = entity.OyuncuResimleri[0].DosyaYolu;
                }
            }

            await _kisiServis.AddAsync(entity.Kisi, userHelper);

            Task[] tasks = new Task[3];
            entity.Id = entity.Kisi.Id;

            tasks[0] = base.AddAsync(entity, userHelper);

            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[1] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri ?? new List<OyuncuResim>(), userHelper);

            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari ?? new List<OyuncuVideo>(), userHelper);

            await Task.WhenAll(tasks);
        }

        public override async Task UpdateAsync(Oyuncu entity, UserHelper userHelper)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            Task[] tasks = new Task[4];
            if (entity.Kisi.ProfilFotoUrl == null)
            {
                if (entity.OyuncuResimleri != null && entity.OyuncuResimleri.Count > 0)
                {
                    entity.Kisi.ProfilFotoUrl = entity.OyuncuResimleri[0].DosyaYolu;
                }
            }


            tasks[0] = _kisiServis.UpdateAsync(entity.Kisi, userHelper);


            tasks[1] = base.UpdateAsync(entity, userHelper);
            if (entity.OyuncuResimleri == null)
                entity.OyuncuResimleri = new List<OyuncuResim>();
            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri, userHelper);

            if (entity.OyuncuVideolari == null)
                entity.OyuncuVideolari = new List<OyuncuVideo>();
            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[3] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari, userHelper);



            await Task.WhenAll(tasks);
            //scope.Complete();
            //}
        }
    }
}
