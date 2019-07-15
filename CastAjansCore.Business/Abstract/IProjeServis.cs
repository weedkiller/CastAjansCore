using Calbay.Core.Business;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IProjeServis : IServiceRepository<Proje>
    {
        Task<ProjeEditDto> GetEditDtoAsync(int? id,int? musteriId);
        Task<Proje> GetAllDetailByIdAsync(int id);
    }
}
