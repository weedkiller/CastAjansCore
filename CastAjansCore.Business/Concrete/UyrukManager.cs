using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class UyrukManager : ManagerRepositoryBase<Uyruk>, IUyrukServis
    {
        public UyrukManager(IEntitiyRepository<Uyruk> dal) : base(dal)
        {

        }
    }
}
