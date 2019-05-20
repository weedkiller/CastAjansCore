using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class IlManager : ManagerRepositoryBase<Il>, IIlServis
    {
        public IlManager(IIlDal dal) : base(dal)
        {

        }
    }
}
