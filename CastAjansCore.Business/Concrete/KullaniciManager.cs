using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {

        private readonly IKisiServis _kisiServis;
        public KullaniciManager(IKullaniciDal dal, IKisiServis kisiServis) : base(dal)
        {
            _kisiServis = kisiServis;
        }

        public override async Task AddAsync(Kullanici entity)
        {
            await _kisiServis.AddAsync(entity.Kisi);
            await base.AddAsync(entity);
        }

        public override async Task UpdateAsync(Kullanici entity)
        {
            Task[] tasks = new Task[2];
            tasks[0]=_kisiServis.UpdateAsync(entity.Kisi);
            tasks[1] = base.UpdateAsync(entity);

            await Task.WhenAll(tasks);
        }
        public async Task<Kullanici> GetWithKisi(int id)
        {
            return await _dal.GetAsync(new List<string> { "Kisi" }, (x => x.Id == id));
        }
    }
}
