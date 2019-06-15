using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IOyuncuResimServis : IServiceRepository<OyuncuResim>
    {
        Task<List<OyuncuResim>> GetListByOyuncuIdAsync(int oyuncuId);
        Task SaveListAsync(List<OyuncuResim> oyuncuResimleri, UserHelper userHelper);
    }
}
