using Calbay.Core.Business;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
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

        Task<GridDto<OyuncuListDto>> GetGridAsync(OyuncuFilterDto filterDto);
        Task AnaResimYap(int id, int resimId, UserHelper userHelper);
    }
}
