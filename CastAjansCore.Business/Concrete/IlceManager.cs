using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class IlceManager : ManagerRepositoryBase<Ilce>, IIlceServis
    {
        public IlceManager(IIlceDal dal) : base(dal)
        {

        }
    }
}
