using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BankaManager : ManagerRepositoryBase<Banka>, IBankaServis
    {
        public BankaManager(IEntitiyRepository<Banka> dal) : base(dal)
        {

        }
    }
}
