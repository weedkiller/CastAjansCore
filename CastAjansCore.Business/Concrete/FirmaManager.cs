using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class FirmaManager : ManagerRepositoryBase<Firma>, IFirmaServis
    {
        public FirmaManager(IFirmaDal dal) : base(dal)
        {

        }
    }
}
