using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class MusteriManager : ManagerRepositoryBase<Musteri>, IMusteriServis
    {
        public MusteriManager(IEntitiyRepository<Musteri> dal) : base(dal)
        {

        }
    }
}
