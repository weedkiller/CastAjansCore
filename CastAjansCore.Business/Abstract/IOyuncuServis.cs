using Calbay.Core.Business;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IOyuncuServis : IServiceRepository<Oyuncu>
    {
        Task<OyuncuEditDto> GetEditDtoAsync(int? id);

        Task<List<OyuncuListDto>> GetListDtoAsync(Expression<Func<Oyuncu, bool>> filter = null);
    }
}
