using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumManager : ManagerRepositoryBase<Bolum>, IBolumServis
    {
        public BolumManager(IBolumDal dal) : base(dal)
        {
        }
    }
}
