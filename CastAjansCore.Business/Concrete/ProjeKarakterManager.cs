using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class ProjeKarakterManager : ManagerRepositoryBase<ProjeKarakter>, IProjeKarakterServis
    {
        public readonly IProjeKarakterOyuncuServis _ProjeKarakterOyuncuServis;
        public ProjeKarakterManager(IProjeKarakterManagerDal dal, IProjeKarakterOyuncuServis projeKarakterOyuncuServis) : base(dal)
        {
            _ProjeKarakterOyuncuServis = projeKarakterOyuncuServis;
        }

        public override async Task AddAsync(ProjeKarakter entity, UserHelper userHelper)
        {
            await base.AddAsync(entity, userHelper);
            await Save_ProjeKarakterOyunculariAsync(entity, userHelper);
        }

        public override async Task UpdateAsync(ProjeKarakter entity, UserHelper userHelper)
        {
            var t1 = base.UpdateAsync(entity, userHelper);
            var t2 = Save_ProjeKarakterOyunculariAsync(entity, userHelper);
            await Task.WhenAll(t1, t2);
        }

        public override async Task SaveAsync(ProjeKarakter entity, UserHelper userHelper)
        {
            await base.SaveAsync(entity, userHelper);
        }

        private async Task Save_ProjeKarakterOyunculariAsync(ProjeKarakter entity, UserHelper userHelper)
        {
            if (entity.ProjeKarakterOyunculari != null)
            {
                var t = new Task[entity.ProjeKarakterOyunculari.Count];
                foreach (var item in entity.ProjeKarakterOyunculari)
                {
                    item.ProjeKarakterId = entity.Id;
                    t[entity.ProjeKarakterOyunculari.IndexOf(item)] = _ProjeKarakterOyuncuServis.SaveAsync(item, userHelper);
                }
                await Task.WhenAll(t);
            }
            else
            {
                await Task.CompletedTask;
            }
        }

        public async Task<List<ProjeKarakter>> GetListByProjeIdAsync(int projeId)
        {
            return await base.GetListAsync(i => i.ProjeId == projeId);
        }

        public async Task UpdateDurumuAsync(string projeGuid, int karakterId, int oyuncuId, EnuKarakterDurumu karakterDurumu, UserHelper userHelper)
        {
            ProjeKarakterOyuncu oyuncu = await _ProjeKarakterOyuncuServis.GetAsync(i => i.ProjeKarakter.Proje.GuidId == new Guid(projeGuid) && i.ProjeKarakter.Proje.Aktif && i.ProjeKarakterId == karakterId && i.ProjeKarakter.Aktif && i.OyuncuId == oyuncuId && i.Aktif);

            switch (karakterDurumu)
            {
                case EnuKarakterDurumu.TeklifAtildi:
                    if (oyuncu.KarakterDurumu == EnuKarakterDurumu.KabulEdildi)
                    {
                        oyuncu.KarakterDurumu = EnuKarakterDurumu.TeklifAtildi;
                    }
                    break;
                case EnuKarakterDurumu.KabulEdildi:
                    if (oyuncu.KarakterDurumu == EnuKarakterDurumu.TeklifAtildi)
                    {
                        oyuncu.KarakterDurumu = EnuKarakterDurumu.KabulEdildi;
                    }
                    break;
                case EnuKarakterDurumu.Oynadi:
                    break;
                default:
                    break;
            }

           

            await _ProjeKarakterOyuncuServis.UpdateAsync(oyuncu, userHelper);
        }
    }
}
