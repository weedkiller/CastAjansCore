using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuResimManager : ManagerRepositoryBase<OyuncuResim>, IOyuncuResimServis
    {
        public OyuncuResimManager(IEntitiyRepository<OyuncuResim> dal) : base(dal)
        {

        }
    }
}
