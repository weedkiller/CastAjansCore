using System.Collections.Generic;
using System.Threading.Tasks;
using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class ProjeManager : ManagerRepositoryBase<Proje>, IProjeServis
    {
        public ProjeManager(IProjeDal dal) : base(dal)
        {

        }

        public override async Task<Proje> GetByIdAsync(int id)
        {
            return await _dal.GetAsync(new List<string> { "ProjeKarakter" }, (x => x.Id == id));           
        }
    }
}
