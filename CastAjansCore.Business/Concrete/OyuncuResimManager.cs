using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuResimManager : ManagerRepositoryBase<OyuncuResim>, IOyuncuResimServis
    {
        private readonly IOyuncuResimDal _oyuncuResimDal;

        public OyuncuResimManager(IOyuncuResimDal dal) : base(dal)
        {
            _oyuncuResimDal = dal;
        }

        public async Task<List<OyuncuResim>> GetListByOyuncuIdAsync(int oyuncuId)
        {
            var list = await base.GetListAsync(i => i.OyuncuId == oyuncuId && i.Aktif == true);

            return list.OrderByDescending(i => i.EklemeZamani).ToList();
        }

        public override async Task AddAsync(OyuncuResim entity, UserHelper userHelper)
        {
            if (userHelper == null)
            {
                userHelper = new UserHelper();
            }
            if (entity.EklemeZamani == null)
            {
                entity.EklemeZamani = DateTime.Now;
                entity.GuncellemeZamani = DateTime.Now;
            }
            entity.EkleyenId = userHelper.Id;
            entity.GuncelleyenId = userHelper.Id;
            entity.Aktif = true;

            await _dal.AddAsync(entity);
        }

        public async Task SaveListAsync(List<OyuncuResim> oyuncuResimleri, UserHelper userHelper)
        {
            var liste = oyuncuResimleri.Where(i => i.Id == 0).ToList();
            Task[] tasks = new Task[liste.Count];
            if (liste.Count > 0)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    tasks[i] = base.AddAsync(liste[i], userHelper);
                }
                await Task.WhenAll(tasks);
            }

            await Task.CompletedTask;
        }

        public void SaveList(List<OyuncuResim> oyuncuResimleri, UserHelper userHelper)
        {
            var liste = oyuncuResimleri.Where(i => i.Id == 0).ToList();

            if (liste.Count > 0)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    base.Add(liste[i], userHelper);
                }
            }
        }
    }
}
