using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuVideoManager : ManagerRepositoryBase<OyuncuVideo>, IOyuncuVideoServis
    {
        public OyuncuVideoManager(IOyuncuVideoDal dal) : base(dal)
        {

        }

        public async Task<List<OyuncuVideo>> GetListByOyuncuIdAsync(int oyuncuId)
        {
            return await base.GetListAsync(i => i.OyuncuId == oyuncuId && i.Aktif == true);
        }

        public async Task SaveListAsync(List<OyuncuVideo> oyuncuVideolari, UserHelper userHelper)
        {
            var liste = oyuncuVideolari.Where(i => i.Id == 0).ToList();
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

        public void SaveList(List<OyuncuVideo> oyuncuVideolari, UserHelper userHelper)
        {
            var liste = oyuncuVideolari.Where(i => i.Id == 0).ToList();
            
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
