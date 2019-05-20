using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuResimManager : ManagerRepositoryBase<OyuncuResim>, IOyuncuResimServis
    {
        public OyuncuResimManager(IOyuncuResimDal dal) : base(dal)
        {

        }
    }
}
