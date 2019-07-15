using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class ProjeManager : ManagerRepositoryBase<Proje>, IProjeServis
    {
        private readonly IProjeKarakterServis _ProjeKarakterServis;
        private readonly IKullaniciServis _KullaniciServis;
        private readonly IUyrukServis _UyrukServis;
        private readonly IMusteriServis _MusteriServis;
        private readonly IProjeKarakterOyuncuServis _ProjeKarakterOyuncuServis;
        public ProjeManager(IProjeDal dal,
                            IMusteriServis musteriServis,
                            IKullaniciServis kullaniciServis,
                            IUyrukServis uyrukServis,
                            IProjeKarakterServis projeKarakterServis,
                            IProjeKarakterOyuncuServis projeKarakterOyuncuServis
                            ) : base(dal)
        {
            _MusteriServis = musteriServis;
            _KullaniciServis = kullaniciServis;
            _ProjeKarakterServis = projeKarakterServis;
            _ProjeKarakterOyuncuServis = projeKarakterOyuncuServis;
            _UyrukServis = uyrukServis;
        }

        public override async Task AddAsync(Proje entity, UserHelper userHelper)
        {
            await base.AddAsync(entity, userHelper);
            await Save_ProjeKarakterAsync(entity, userHelper);
        }

        public async Task<Proje> GetAllDetailByIdAsync(int id)
        {
            var entity = await _dal.GetAsync(new List<string>
            {
                "Musteri",
                "IsiTakipEden",
                "IsiTakipEden.Kisi"
                //"ProjeKarakterleri",
                //"ProjeKarakterleri.ProjeKarakterOyunculari",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.Kisi",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.OyuncuResimleri",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.OyuncuVideolari"
            }, i =>
            i.Id == id &&
            i.Aktif == true &&
            i.Musteri.Aktif == true
            );

            entity.ProjeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(entity.Id);
            foreach (var item in entity.ProjeKarakterleri)
            {
                item.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
            }

            return entity;
        }

        public async Task<ProjeEditDto> GetEditDtoAsync(int? id, int? musteriId)
        {
            var tKul = _KullaniciServis.GetSelectListAsync();
            var tUyruk = _UyrukServis.GetSelectListAsync();
            var projeEditDto = new ProjeEditDto()
            {
                Kullanicilar = await tKul,
                OyuncuFilterDto = new OyuncuFilterDto { Uyruklar = await tUyruk }
            };

            if (id == null)
            {
                projeEditDto.Proje = new Proje
                {
                    MusteriId = musteriId.Value,
                    TarihBas = DateTime.Today,
                    TarihBit = DateTime.Today,
                    Musteri = await _MusteriServis.GetByIdAsync(musteriId.Value),
                    ProjeKarakterleri = new List<ProjeKarakter>(),
                };
            }
            else
            {
                projeEditDto.Proje = await base.GetByIdAsync(id.Value);
                projeEditDto.Proje.Musteri = await _MusteriServis.GetByIdAsync(projeEditDto.Proje.MusteriId);
                projeEditDto.Proje.ProjeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(id.Value);
                foreach (var item in projeEditDto.Proje.ProjeKarakterleri)
                {
                    item.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
                }
            }

            return projeEditDto;
        }

        public override async Task UpdateAsync(Proje entity, UserHelper userHelper)
        {
            var t1 = base.UpdateAsync(entity, userHelper);
            var t2 = Save_ProjeKarakterAsync(entity, userHelper);
            await Task.WhenAll(t1, t2);
        }

        private async Task Save_ProjeKarakterAsync(Proje entity, UserHelper userHelper)
        {
            if (entity.ProjeKarakterleri != null)
            {
                var t = new Task[entity.ProjeKarakterleri.Count];
                foreach (var item in entity.ProjeKarakterleri)
                {
                    item.ProjeId = entity.Id;
                    t[entity.ProjeKarakterleri.IndexOf(item)] = _ProjeKarakterServis.SaveAsync(item, userHelper);
                }
                await Task.WhenAll(t);
            }
            else
            {
                await Task.CompletedTask;
            }
        }

        //public override async Task<Proje> GetByIdAsync(int id)
        //{
        //    return await _dal.GetAsync(new List<string> { "ProjeKarakter" }, (x => x.Id == id));           
        //}
    }
}
