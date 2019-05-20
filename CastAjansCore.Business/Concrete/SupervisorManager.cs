using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class SupervisorManager : ManagerRepositoryBase<Supervisor>, ISupervisorServis
    {
        public SupervisorManager(ISupervisorDal dal) : base(dal)
        {

        }
    }
}
