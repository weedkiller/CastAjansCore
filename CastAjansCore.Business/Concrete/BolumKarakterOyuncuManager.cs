using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterOyuncuManager : ManagerRepositoryBase<BolumKarakterOyuncu>, IBolumKarakterOyuncuServis
    {
        public BolumKarakterOyuncuManager(IEntitiyRepository<BolumKarakterOyuncu> dal) : base(dal)
        {

        }
    }
}
