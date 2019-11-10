using Calbay.Core.Business;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class BolumKarakterOyuncuManager : ManagerRepositoryBase<ProjeKarakterOyuncu>, IProjeKarakterOyuncuServis
    {
        public BolumKarakterOyuncuManager(IProjeKarakterOyuncuDal dal) : base(dal)
        {

        }

        public async Task<List<ProjeKarakterOyuncu>> GetListByProjeKarakterIdAsync(int projeKarakterId)
        {
            return await base._dal.GetListAsync(new List<string> { "Oyuncu", "Oyuncu.Kisi", "Oyuncu.Kisi.Ilce", "Oyuncu.Kisi.Ilce.Il" },
                i => i.ProjeKarakterId == projeKarakterId &&
                i.Aktif == true //&&
                //i.Oyuncu.Aktif == true &&
                //i.Oyuncu.Kisi.Aktif == true
                );
        }
    }
}
