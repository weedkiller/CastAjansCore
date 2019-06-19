using Calbay.Core.Business;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IProjeKarakterServis : IServiceRepository<ProjeKarakter>
    {
        Task<List<ProjeKarakter>> GetListByProjeIdAsync(int value);
    }
}
