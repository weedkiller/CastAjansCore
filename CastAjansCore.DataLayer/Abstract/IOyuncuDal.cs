using Calbay.Core.DataAccess;
using Calbay.Core.Entities;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.DataLayer.Abstract
{
    public interface IOyuncuDal : IEntitiyRepository<Oyuncu>
    {
        Task<GridDto<OyuncuListDto>> GetGridAsync(int start, int pageSize, Expression<Func<Oyuncu, bool>> filter = null);        
    }
}
