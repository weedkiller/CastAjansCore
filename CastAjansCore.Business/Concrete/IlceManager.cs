using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class IlceManager : ManagerRepositoryBase<Ilce>, IIlceServis
    {
        public IlceManager(IEntitiyRepository<Ilce> dal) : base(dal)
        {

        }
    }
}
