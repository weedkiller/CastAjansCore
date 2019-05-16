using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KisiBankaManager : ManagerRepositoryBase<KisiBanka>, IKisiBankaServis
    {
        public KisiBankaManager(IEntitiyRepository<KisiBanka> dal) : base(dal)
        {

        }
    }
}
