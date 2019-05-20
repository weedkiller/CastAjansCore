using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class TelefonManager : ManagerRepositoryBase<Telefon>, ITelefonServis
    {
        public TelefonManager(ITelefonDal dal) : base(dal)
        {

        }
    }
}
