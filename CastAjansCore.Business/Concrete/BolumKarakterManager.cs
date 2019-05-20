using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterManager : ManagerRepositoryBase<BolumKarakter>, IBolumKarakterServis
    {
        public BolumKarakterManager(IBolumKarakterDal dal) : base(dal)
        {

        }
    }
}
