using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CastAjansCore.Business.Concrete
{
    public class AdresServis : IAdresServis
    {
        public IAdresDal _adresDal;

        public AdresServis(IAdresDal adresDal)
        {
            _adresDal = adresDal;
        }

        public void Add(AdresEditDto entity)
        {
            Adres adres = new Adres();
            adres.Default = entity.Default;
            adres.Adress = entity.Adress;
            adres.IlceId = entity.IlceId;
            adres.KisiId = entity.KisiId;
            adres.Tanim = entity.Tanim;
            adres.EkleyenId = 1;
            adres.GuncelleyenId = 1;
            adres.EklemeZamani = DateTime.Now;
            adres.GuncellemeZamani = DateTime.Now;
            adres.Aktif = true;

            _adresDal.Add(adres);
        }

        public void Delete(int id)
        {
            //_adresDal.Delete(Get(filter => filter.Id = id));
        }

        public AdresEditDto Get(Expression<Func<AdresEditDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<AdresListDto> GetList(Expression<Func<AdresListDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(AdresEditDto entity)
        {
            Adres adres = new Adres();
            adres.Default = entity.Default;
            adres.Adress = entity.Adress;
            adres.IlceId = entity.IlceId;
            adres.KisiId = entity.KisiId;
            adres.Tanim = entity.Tanim;
            adres.GuncelleyenId = 1;
            adres.GuncellemeZamani = DateTime.Now;

            _adresDal.Update(adres);
        }
    }
}
