using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        public override void Add(Kisi entity, UserHelper userHelper)
        {
            base.Add(entity, userHelper);
        }

        private async Task Kontrol(Kisi entity)
        {
            var tTC = GetAsync(i => (entity.Id == 0 || i.Id != entity.Id) && i.TC == entity.TC && i.Aktif == true);
            var tEPosta = GetAsync(i => (entity.Id == 0 || i.Id != entity.Id) && i.TC == entity.EPosta && i.Aktif == true);

            if (await tTC != null)
            {
                throw new Exception($"{entity.TC} TC'li kayıt mevcuttur.");
            }

            if (await tEPosta != null)
            {
                throw new Exception($"{entity.EPosta} E-Postalı kayıt mevcuttur.");
            }
        }

        public override async Task AddAsync(Kisi entity, UserHelper userHelper)
        {
            await Kontrol(entity);
            await base.AddAsync(entity, userHelper);
        }


        public List<Kisi> GetByKanGrubu(EnuKanGrubu kanGrubu)
        {
            return base._dal.GetList(k => k.KanGrubu == kanGrubu);
        }

        public async Task<KisiEditDto> GetEditDtoAsync(int? id)
        {
            KisiEditDto kisiEditDto = new KisiEditDto();
            var tUyruk = _uyrukServis.GetSelectListAsync(i => i.Aktif == true);
            var tIller = _IlServis.GetSelectListAsync(i => i.Aktif == true);
            var tBankalar = _bankaServis.GetSelectListAsync(i => i.Aktif == true);

            kisiEditDto.Uyruklar = await tUyruk;
            kisiEditDto.Iller = await tIller;
            kisiEditDto.Bankalar = await tBankalar;

            if (id != null)
            {
                Task<Kisi> tkisi = GetByIdAsync(id.Value);

                kisiEditDto.Kisi = await tkisi;
                if (kisiEditDto.Kisi.IlceId.IsNotNull())
                {
                    kisiEditDto.Kisi.Ilce = await _IlceServis.GetByIdAsync(kisiEditDto.Kisi.IlceId.Value);
                    var tilceler = _IlceServis.GetSelectListAsync(i => i.IlId == kisiEditDto.Kisi.Ilce.IlId.ToInt(0) && i.Aktif == true);
                    kisiEditDto.Ilceler = await tilceler;
                }
            }
            return kisiEditDto;
        }
    }
}