using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class ProjeManager : ManagerRepositoryBase<Proje>, IProjeServis
    {
        public ProjeManager(IEntitiyRepository<Proje> dal) : base(dal)
        {

        }
    }
}
