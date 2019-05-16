using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuManager : ManagerRepositoryBase<Oyuncu>, IOyuncuServis
    {
        public OyuncuManager(IEntitiyRepository<Oyuncu> dal) : base(dal)
        {

        }
    }
}
