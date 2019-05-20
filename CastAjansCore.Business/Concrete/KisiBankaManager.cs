using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KisiBankaManager : ManagerRepositoryBase<KisiBanka>, IKisiBankaServis
    {
        public KisiBankaManager(IKisiBankaDal dal) : base(dal)
        {

        }
    }
}
