using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuVideoManager : ManagerRepositoryBase<OyuncuVideo>, IOyuncuVideoServis
    {
        public OyuncuVideoManager(IEntitiyRepository<OyuncuVideo> dal) : base(dal)
        {

        }
    }
}
