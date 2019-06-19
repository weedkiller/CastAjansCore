using System.Collections.Generic;
using System.Threading.Tasks;
using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

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
    }
}
