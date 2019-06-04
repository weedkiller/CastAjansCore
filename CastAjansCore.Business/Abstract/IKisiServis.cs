using Calbay.Core.Business;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IKisiServis : IServiceRepository<Kisi>
    {
        List<Kisi> GetByKanGrubu(EnuKanGrubu kanGrubu);

        Task<KisiEditDto> GetEditDtoAsync(int? id);
    }
}
