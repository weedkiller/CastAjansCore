using Calbay.Core.Business;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class OyuncuManager : ManagerRepositoryBase<Oyuncu>, IOyuncuServis
    {
        private readonly IOyuncuDal _oyuncuDal;
        private readonly IKisiServis _kisiServis;
        private readonly IOyuncuResimServis _OyuncuResimServis;
        private readonly IOyuncuVideoServis _OyuncuVideoServis;

        public OyuncuManager(IOyuncuDal dal, IKisiServis kisiServis, IOyuncuResimServis oyuncuResimServis, IOyuncuVideoServis oyuncuVideoServis) : base(dal)
        {
            _oyuncuDal = dal;
            _kisiServis = kisiServis;
            _OyuncuResimServis = oyuncuResimServis;
            _OyuncuVideoServis = oyuncuVideoServis;
        }

        public async Task<OyuncuEditDto> GetEditDtoAsync(int? id)
        {
            OyuncuEditDto OyuncuEditDto = new OyuncuEditDto();
            Task<KisiEditDto> tKisiEditDto = _kisiServis.GetEditDtoAsync(id);

            if (id == null)
            {
                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
                OyuncuEditDto.Oyuncu = new Oyuncu();
            }
            else
            {
                Task<Oyuncu> tOyuncu = base.GetByIdAsync(id.Value);

                Task<List<OyuncuResim>> tOyuncuResimleri = _OyuncuResimServis.GetListByOyuncuIdAsync(id.Value);
                Task<List<OyuncuVideo>> tOyuncuVideolari = _OyuncuVideoServis.GetListByOyuncuIdAsync(id.Value);

                OyuncuEditDto.Oyuncu = await tOyuncu;
                OyuncuEditDto.CastTipleri = new List<int>();
                if ((bool)OyuncuEditDto.Oyuncu.CT_AnaCast.IfIsNull(false))
                    OyuncuEditDto.CastTipleri.Add(EnuCastTipi.AnaCast.ToInt());
                if ((bool)OyuncuEditDto.Oyuncu.CT_YardımciOyuncu.IfIsNull(false))
                    OyuncuEditDto.CastTipleri.Add(EnuCastTipi.YardımciOyuncu.ToInt());
                if ((bool)OyuncuEditDto.Oyuncu.CT_OnFGR.IfIsNull(false))
                    OyuncuEditDto.CastTipleri.Add(EnuCastTipi.FGR.ToInt());

                OyuncuEditDto.KisiEditDto = await tKisiEditDto;
                OyuncuEditDto.Oyuncu.OyuncuResimleri = await tOyuncuResimleri;
                OyuncuEditDto.Oyuncu.OyuncuVideolari = await tOyuncuVideolari;
            }

            return OyuncuEditDto;
        }

        public override async Task<Oyuncu> GetByIdAsync(int id)
        {
            return await _dal.GetAsync(new List<string> { "Kisi" }, i => i.Id == id && i.Aktif == true);
        }

        public override async Task DeleteAsync(int id, UserHelper userHelper)
        {
            var tKisi = _kisiServis.DeleteAsync(id, userHelper);
            var tOyuncu = base.DeleteAsync(id, userHelper);
            await Task.WhenAll(tKisi, tOyuncu);
        }

        public override async Task AddAsync(Oyuncu entity, UserHelper userHelper)
        {
            if (entity.Kisi.ProfilFotoUrl == null)
            {
                if (entity.OyuncuResimleri.Count > 0)
                {
                    entity.Kisi.ProfilFotoUrl = entity.OyuncuResimleri[0].DosyaYolu;
                }
            }

            await _kisiServis.AddAsync(entity.Kisi, userHelper);

            Task[] tasks = new Task[3];
            entity.Id = entity.Kisi.Id;

            tasks[0] = base.AddAsync(entity, userHelper);

            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[1] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri ?? new List<OyuncuResim>(), userHelper);

            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari ?? new List<OyuncuVideo>(), userHelper);

            await Task.WhenAll(tasks);
        }

        public override async Task UpdateAsync(Oyuncu entity, UserHelper userHelper)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
            Task[] tasks = new Task[4];
            if (entity.Kisi.ProfilFotoUrl == null)
            {
                if (entity.OyuncuResimleri != null && entity.OyuncuResimleri.Count > 0)
                {
                    entity.Kisi.ProfilFotoUrl = entity.OyuncuResimleri[0].DosyaYolu;
                }
            }


            tasks[0] = _kisiServis.UpdateAsync(entity.Kisi, userHelper);


            tasks[1] = base.UpdateAsync(entity, userHelper);
            if (entity.OyuncuResimleri == null)
                entity.OyuncuResimleri = new List<OyuncuResim>();
            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[2] = _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri, userHelper);

            if (entity.OyuncuVideolari == null)
                entity.OyuncuVideolari = new List<OyuncuVideo>();
            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            tasks[3] = _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari, userHelper);



            await Task.WhenAll(tasks);
            //scope.Complete();
            //}
        }

        public override void Update(Oyuncu entity, UserHelper userHelper)
        {
            if (entity.Kisi.ProfilFotoUrl == null)
            {
                if (entity.OyuncuResimleri != null && entity.OyuncuResimleri.Count > 0)
                {
                    entity.Kisi.ProfilFotoUrl = entity.OyuncuResimleri[0].DosyaYolu;
                }
            }


            _kisiServis.Update(entity.Kisi, userHelper);
            base.Update(entity, userHelper);

            if (entity.OyuncuResimleri == null)
                entity.OyuncuResimleri = new List<OyuncuResim>();
            foreach (var item in entity.OyuncuResimleri.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            _OyuncuResimServis.SaveListAsync(entity.OyuncuResimleri, userHelper);

            if (entity.OyuncuVideolari == null)
                entity.OyuncuVideolari = new List<OyuncuVideo>();
            foreach (var item in entity.OyuncuVideolari.Where(i => i.OyuncuId == 0))
            {
                item.OyuncuId = entity.Kisi.Id;
            }
            _OyuncuVideoServis.SaveListAsync(entity.OyuncuVideolari, userHelper);
        }

        public override List<Oyuncu> GetList(Expression<Func<Oyuncu, bool>> filter = null)
        {
            return _dal.GetList(new List<string> { "Kisi" }, filter);
        }

        public Task<List<OyuncuListDto>> GetListDtoAsync(Expression<Func<Oyuncu, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        //public Task<GridDto<OyuncuListDto>> GetGridAsync(OyuncuFilterDto filterDto)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<GridDto<OyuncuListDto>> GetGridAsync(OyuncuFilterDto filterDto)
        //{
        //    //List<OyuncuListDto> listDto = new List<OyuncuListDto>();
        //    var grid = await base._dal.GetGridAsync(start, pageSize, filter);

        //    //foreach (var item in grid.Data)
        //    //{
        //    //    listDto.Add(new OyuncuListDto
        //    //    {
        //    //        Id = item.Id,
        //    //        Adi = item.Kisi.Adi,
        //    //        Soyadi = item.Kisi.Soyadi,
        //    //        DogumTarihi = item.Kisi.DogumTarihi,
        //    //        ProfilFotoUrl = item.Kisi.ProfilFotoUrl,
        //    //        Kase = item.Kase,
        //    //        Uyruk = item.Kisi.Uyruk.Adi,
        //    //        Cinsiyet = item.Kisi.Cinsiyet.ToDisplay(),
        //    //        Boy = item.Boy,
        //    //        Kilo = item.Kilo,
        //    //        AltBeden = item.AltBeden,
        //    //        UstBeden = item.UstBeden,
        //    //        GozRengi = item.GozRengi.ToDisplay(),
        //    //        TenRengi = item.TenRengi.ToDisplay(),
        //    //        SacRengi = item.SacRengi.ToDisplay(),

        //    //    }
        //    //    );
        //    //}

        //    return grid;
        //}
        public async Task<GridDto<OyuncuListDto>> GetGridAsync(OyuncuFilterDto filter)
        {
            var data = await _oyuncuDal.GetGridAsync(filter.Start, filter.Length, i =>
                     (filter.TC == null || i.Kisi.TC.StartsWith(filter.TC)) &&
                    (filter.Adi == null || i.Kisi.Adi.StartsWith(filter.Adi)) &&
                    (filter.Soyadi == null || i.Kisi.Soyadi.StartsWith(filter.Soyadi)) &&
                    (filter.YasMin == 0 || i.Kisi.DogumTarihi <= DateTime.Today.AddYears(-1 * filter.YasMin)) &&
                    (filter.YasMaks == 0 || i.Kisi.DogumTarihi >= DateTime.Today.AddYears(-1 * filter.YasMaks)) &&
                    (filter.Cinsiyet == 0 || i.Kisi.Cinsiyet == (EnuCinsiyet)filter.Cinsiyet) &&
                    (
                        filter.CastTipi == 0 ||
                        (
                            (filter.CastTipi == EnuCastTipi.YardımciOyuncu.ToInt() && i.CT_YardımciOyuncu == true) ||
                            (filter.CastTipi == EnuCastTipi.FGR.ToInt() && i.CT_OnFGR == true) ||
                            (filter.CastTipi == EnuCastTipi.AnaCast.ToInt() && i.CT_AnaCast == true)
                        )
                    ) &&
                    (filter.Uyruk == 0 || i.Kisi.UyrukId == filter.Uyruk) &&
                    (filter.Il == 0 || i.Kisi.Ilce.IlId == filter.Il) &&
                    (filter.Ilce == 0 || i.Kisi.IlceId == filter.Ilce) &&
                    (filter.KaseMin == 0 || i.Kase >= filter.KaseMin) &&
                    (filter.KaseMaks == 0 || i.Kase <= filter.KaseMaks) &&
                    (filter.BoyMin == 0 || i.Boy >= filter.BoyMin) &&
                    (filter.BoyMaks == 0 || i.Boy <= filter.BoyMaks) &&
                    (filter.KiloMin == 0 || i.Kilo >= filter.KiloMin) &&
                    (filter.KiloMaks == 0 || i.Kilo <= filter.KiloMaks) &&
                    (filter.AltBedenMin == 0 || i.AltBeden >= filter.AltBedenMin) &&
                    (filter.AltBedenMaks == 0 || i.AltBeden <= filter.AltBedenMaks) &&
                    (filter.UstBedenMin == 0 || i.UstBeden >= filter.UstBedenMin) &&
                    (filter.UstBedenMaks == 0 || i.UstBeden <= filter.UstBedenMaks) &&
                    (filter.AyakNumarasiMin == 0 || i.AyakNumarasi >= filter.AyakNumarasiMin) &&
                    (filter.AyakNumarasiMaks == 0 || i.AyakNumarasi <= filter.AyakNumarasiMaks) &&
                    (filter.GozRengi == 0 || i.GozRengi == (EnuGozRengi)filter.GozRengi) &&
                    (filter.TenRengi == 0 || i.TenRengi == (EnuTenRengi)filter.TenRengi) &&
                    (filter.SacRengi == 0 || i.SacRengi == (EnuSacRengi)filter.SacRengi) &&
                    (filter.Ehliyet == null || i.Ehliyet.Contains(filter.Ehliyet)) &&
                    (
                        filter.Genel == null ||
                        (i.Aciklama.Contains(filter.Genel)) ||
                        (i.YabanciDil.Contains(filter.Genel)) ||
                        (i.Yetenekleri.Contains(filter.Genel)) ||
                        (i.Tecrubeler.Contains(filter.Genel)) ||
                        (i.OyuculukEgitimi.Contains(filter.Genel)) ||
                        (i.Meslek.Contains(filter.Genel))
                    ) &&
                    i.Aktif == true && i.Kisi.Aktif == true
                );

            data.Draw = filter.Draw;
            data.length = filter.Length;

            return data;
        }

        public async Task AnaResimYap(int id, int resimId, UserHelper userHelper)
        {
            var kisi = await _kisiServis.GetByIdAsync(id);
            var resim = await _OyuncuResimServis.GetByIdAsync(resimId);
            kisi.ProfilFotoUrl = resim.DosyaYolu;

            await _kisiServis.UpdateAsync(kisi, userHelper);
        }
        public async Task ResmiDondur(int id, int resimId, UserHelper userHelper)
        {
            var resim = await _OyuncuResimServis.GetByIdAsync(resimId);
            var image = new Bitmap(resim.DosyaYolu);

            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            image.Save(resim.DosyaYolu);
        }
    }
}
