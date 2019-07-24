using Calbay.Core.DataAccess;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System.Threading.Tasks;

namespace CastAjansCore.DataLayer.Abstract
{
    public interface IProjeDal : IEntitiyRepository<Proje>
    {
        Task<ProjeDetailDto> GetDetailByGuidIdAsync(string guidId);
    }
}
