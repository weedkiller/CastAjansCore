using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using System.Collections.Generic;

namespace CastAjansCore.Business.Concrete
{
    public class KisiManager : ManagerRepositoryBase<Kisi>, IKisiServis
    {        
        public KisiManager(IKisiDal dal) : base(dal)
        {
        }

        public List<Kisi> GetByKanGrubu(EnuKanGrubu kanGrubu)
        {
            return base._dal.GetList(k => k.KanGrubu == kanGrubu);
        }
    }
}
