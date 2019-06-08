using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class KisiManager : ManagerRepositoryBase<Kisi>, IKisiServis
    {
        IIlServis _IlServis;
        IIlceServis _IlceServis;
        IUyrukServis _uyrukServis;
        IBankaServis _bankaServis;

        public KisiManager(IKisiDal dal,
            IIlServis ilServis,
            IIlceServis ilceServis,
            IUyrukServis uyrukServis,
            IBankaServis bankaServis
            ) : base(dal)
        {
            _IlServis = ilServis;
            _IlceServis = ilceServis;
            _uyrukServis = uyrukServis;
            _bankaServis = bankaServis;
        }

        public List<Kisi> GetByKanGrubu(EnuKanGrubu kanGrubu)
        {
            return base._dal.GetList(k => k.KanGrubu == kanGrubu);
        }

        public async Task<KisiEditDto> GetEditDtoAsync(int? id)
        {
            KisiEditDto kisiEditDto = new KisiEditDto();
            Task<List<Uyruk>> tUyruk = _uyrukServis.GetListAsync();
            Task<List<Il>> tIller = _IlServis.GetListAsync();
            Task<List<Banka>> tBankalar = _bankaServis.GetListAsync();

            kisiEditDto.Uyruklar.Add(new SelectListItem("Seçiniz", ""));
            foreach (var item in await tUyruk)
            {
                kisiEditDto.Uyruklar.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            }

            kisiEditDto.Iller.Add(new SelectListItem("Seçiniz", ""));
            var iller = (await tIller).OrderBy(i => i.Adi).ToList();
            foreach (var item in iller)
            {
                kisiEditDto.Iller.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            }

            kisiEditDto.Bankalar.Add(new SelectListItem("Seçiniz", ""));
            foreach (var item in await tBankalar)
            {
                kisiEditDto.Bankalar.Add(new SelectListItem(item.Adi, item.Id.ToString()));
            }

            if (id != null)
            {
                Task<Kisi> tkisi = GetByIdAsync(id.Value);

                kisiEditDto.Kisi = await tkisi;
                if (kisiEditDto.Kisi.IlceId.IsNotNull())
                {
                    kisiEditDto.Kisi.Ilce = await _IlceServis.GetByIdAsync(kisiEditDto.Kisi.IlceId.Value);
                    var ilceler = (await _IlceServis.GetListAsync(i => i.IlId == kisiEditDto.Kisi.Ilce.IlId.ToInt(0))).OrderBy(i => i.Adi).ToList();
                    kisiEditDto.Ilceler.Add(new SelectListItem("Seçiniz", ""));
                    foreach (var item in ilceler)
                    {
                        kisiEditDto.Ilceler.Add(new SelectListItem(item.Adi, item.Id.ToString()));
                    }
                }
            }
            return kisiEditDto;
        }
    }
}