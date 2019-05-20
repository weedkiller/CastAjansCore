using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BankaManager : ManagerRepositoryBase<Banka>, IBankaServis
    {
        public BankaManager(IBankaDal dal) : base(dal)
        {

        }
    }
}
