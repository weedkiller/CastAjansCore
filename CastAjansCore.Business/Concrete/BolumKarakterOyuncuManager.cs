using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterOyuncuManager : ManagerRepositoryBase<ProjeKarakterOyuncu>, IProjeKarakterOyuncuServis
    {
        public BolumKarakterOyuncuManager(IProjeKarakterOyuncuDal dal) : base(dal)
        {

        }
    }
}
