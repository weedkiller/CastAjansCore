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
    public class ProjeManager : ManagerRepositoryBase<Proje>, IProjeServis
    {
        public readonly IProjeKarakterServis _ProjeKarakterServis;
        public ProjeManager(IProjeDal dal, IProjeKarakterServis karakterServis) : base(dal)
        {
            _ProjeKarakterServis = karakterServis;
        }

        public override async Task AddAsync(Proje entity, UserHelper userHelper)
        {
            await base.AddAsync(entity, userHelper);
            await Save_ProjeKarakterAsync(entity, userHelper);
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
