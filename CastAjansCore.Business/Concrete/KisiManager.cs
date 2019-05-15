using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KisiManager : ManagerRepositoryBase<Kisi>, IKisiServis
    {
        public KisiManager(IEntitiyRepository<Kisi> dal) : base(dal)
        {
        }
    }
}
