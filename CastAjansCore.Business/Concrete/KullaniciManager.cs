using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {
        public KullaniciManager(IEntitiyRepository<Kullanici> dal) : base(dal)
        {

        }
    }
}
