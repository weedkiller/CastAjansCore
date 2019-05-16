using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class TelefonManager : ManagerRepositoryBase<Telefon>, ITelefonServis
    {
        public TelefonManager(IEntitiyRepository<Telefon> dal) : base(dal)
        {

        }
    }
}
