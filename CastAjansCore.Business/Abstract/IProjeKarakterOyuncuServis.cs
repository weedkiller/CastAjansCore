using Calbay.Core.Business;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IProjeKarakterOyuncuServis : IServiceRepository<ProjeKarakterOyuncu>
    {
        Task<List<ProjeKarakterOyuncu>> GetListByProjeKarakterIdAsync(int projeKarakterId);
    }
}
