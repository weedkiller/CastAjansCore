using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterOyuncuManager : ManagerRepositoryBase<BolumKarakterOyuncu>, IBolumKarakterOyuncuServis
    {
        public BolumKarakterOyuncuManager(IBolumKarakterOyuncuDal dal) : base(dal)
        {

        }
    }
}
