using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IProjeKarakterServis : IServiceRepository<ProjeKarakter>
    {
        Task<List<ProjeKarakter>> GetListByProjeIdAsync(int value);
        Task UpdateDurumuAsync(string projeGuid, int karakterId, int oyuncuId, EnuKarakterDurumu karakterDurumu, UserHelper userHelper);
    }
}
