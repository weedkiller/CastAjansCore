using System.Threading.Tasks;
using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class MusteriManager : ManagerRepositoryBase<Musteri>, IMusteriServis
    {
        public MusteriManager(IMusteriDal dal) : base(dal)
        {
            
        }
    }
}
