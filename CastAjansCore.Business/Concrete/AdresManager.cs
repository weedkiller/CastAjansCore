using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CastAjansCore.Business.Concrete
{
    public class AdresManager : ManagerRepositoryBase<Adres>, IAdresServis
    {
        public AdresManager(IEntitiyRepository<Adres> dal) : base(dal)
        {
        }
    }
}
