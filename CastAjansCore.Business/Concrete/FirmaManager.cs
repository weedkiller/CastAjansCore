﻿using Calbay.Core.Business;
using Calbay.Core.DataAccess;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class FirmaManager : ManagerRepositoryBase<Firma>, IFirmaServis
    {
        public FirmaManager(IEntitiyRepository<Firma> dal) : base(dal)
        {

        }
    }
}