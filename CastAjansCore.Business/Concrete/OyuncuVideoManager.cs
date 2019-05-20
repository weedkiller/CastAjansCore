using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuVideoManager : ManagerRepositoryBase<OyuncuVideo>, IOyuncuVideoServis
    {
        public OyuncuVideoManager(IOyuncuVideoDal dal) : base(dal)
        {

        }
    }
}
