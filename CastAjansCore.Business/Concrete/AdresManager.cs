using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class AdresManager : ManagerRepositoryBase<Adres>, IAdresServis
    {
        public AdresManager(IAdresDal dal) : base(dal)
        {
        }
    }
}
