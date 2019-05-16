using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class IlManager : ManagerRepositoryBase<Il>, IIlServis
    {
        public IlManager(IEntitiyRepository<Il> dal) : base(dal)
        {

        }
    }
}
