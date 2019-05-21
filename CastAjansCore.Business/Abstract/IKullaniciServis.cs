using Calbay.Core.Business;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Abstract
{
    public interface IKullaniciServis : IServiceRepository<Kullanici>
    {
        Task<Kullanici> GetWithKisi(int id);
    }
}
