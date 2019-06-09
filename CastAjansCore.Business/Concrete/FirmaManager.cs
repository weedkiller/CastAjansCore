using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class FirmaManager : ManagerRepositoryBase<Firma>, IFirmaServis
    {
        public FirmaManager(UserHelper userHelper, IFirmaDal dal) : base(dal)
        {

        }
    }
}
