using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class BolumManager : ManagerRepositoryBase<Bolum>, IBolumServis
    {
        public BolumManager(IEntitiyRepository<Bolum> dal) : base(dal)
        {
        }
    }
}
