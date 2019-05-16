using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterManager : ManagerRepositoryBase<BolumKarakter>, IBolumKarakterServis
    {
        public BolumKarakterManager(IEntitiyRepository<BolumKarakter> dal) : base(dal)
        {

        }
    }
}
