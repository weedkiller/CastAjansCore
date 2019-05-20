using System.Threading.Tasks;
using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;

namespace CastAjansCore.Business.Concrete
{
    public class KullaniciManager : ManagerRepositoryBase<Kullanici>, IKullaniciServis
    {

        private readonly IKisiServis _kisiServis;
        public KullaniciManager(IKullaniciDal dal, IKisiServis kisiServis) : base(dal)
        {
            _kisiServis = kisiServis;
        }

        public override Task AddAsync(Kullanici entity)
        {
            _kisiServis.Add(entity.Kisi);            
             return base.AddAsync(entity);
        }


    }
}
