using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IOyuncuVideoServis : IServiceRepository<OyuncuVideo>
    {
        Task<List<OyuncuVideo>> GetListByOyuncuIdAsync(int oyuncuId);
        Task SaveListAsync(List<OyuncuVideo> oyuncuVideolari, UserHelper userHelper);
    }
}
