﻿using Calbay.Core.DataAccess;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.DataLayer.Concrete.EntityFramework
{
    public class EfKisiBankaDal : EfEntityRepositoryBase<KisiBanka, CastAjansContext>, IKisiBankaDal
    {

    }
}
