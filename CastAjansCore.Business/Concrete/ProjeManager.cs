using Calbay.Core.Business;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.Dto;
using CastAjansCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastAjansCore.Business.Concrete
{
    public class ProjeManager : ManagerRepositoryBase<Proje>, IProjeServis
    {
        private readonly IProjeDal _projeDal;
        private readonly IProjeKarakterServis _ProjeKarakterServis;
        private readonly IKullaniciServis _KullaniciServis;
        private readonly IUyrukServis _UyrukServis;
        private readonly IIlServis _IlServis;
        private readonly IOyuncuResimServis _oyuncuResimServis;
        private readonly IOyuncuVideoServis _oyuncuVideoServis;
        private readonly IMusteriServis _MusteriServis;
        private readonly IProjeKarakterOyuncuServis _ProjeKarakterOyuncuServis;

        public ProjeManager(IProjeDal dal,
                            IMusteriServis musteriServis,
                            IKullaniciServis kullaniciServis,
                            IUyrukServis uyrukServis,
                            IIlServis ilServis,
                            IProjeKarakterServis projeKarakterServis,
                            IProjeKarakterOyuncuServis projeKarakterOyuncuServis,
                            IOyuncuResimServis oyuncuResimServis,
                            IOyuncuVideoServis oyuncuVideoServis
                            ) : base(dal)
        {
            _projeDal = dal;
            _MusteriServis = musteriServis;
            _KullaniciServis = kullaniciServis;
            _ProjeKarakterServis = projeKarakterServis;
            _ProjeKarakterOyuncuServis = projeKarakterOyuncuServis;
            _UyrukServis = uyrukServis;
            _IlServis = ilServis;
            _oyuncuResimServis = oyuncuResimServis;
            _oyuncuVideoServis = oyuncuVideoServis;
        }

        public override async Task AddAsync(Proje entity, UserHelper userHelper)
        {
            await base.AddAsync(entity, userHelper);
            await Save_ProjeKarakterAsync(entity, userHelper);
        }

        public async Task<Proje> GetAllDetailByIdAsync(int id)
        {
            var entity = await _dal.GetAsync(new List<string>
            {
                "Musteri",
                "IsiTakipEden",
                "IsiTakipEden.Kisi"
                //"ProjeKarakterleri",
                //"ProjeKarakterleri.ProjeKarakterOyunculari",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.Kisi",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.OyuncuResimleri",
                //"ProjeKarakterleri.ProjeKarakterOyunculari.Oyuncu.OyuncuVideolari"
            }, i =>
            i.Id == id &&
            i.Aktif == true &&
            i.Musteri.Aktif == true
            );

            entity.ProjeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(entity.Id);
            foreach (var item in entity.ProjeKarakterleri)
            {
                item.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
            }

            return entity;
        }

        public async Task<ProjeDetailDto> GetDetailAsync(string guidId)
        {
            //ProjeDetailDto projeDetailDto = await _projeDal.GetDetailByGuidIdAsync(guidId);
            Proje proje = await _dal.GetAsync(new List<string> { "Musteri", "IsiTakipEden", "IsiTakipEden.Kisi" }, i => i.GuidId == new Guid(guidId) && i.Aktif == true);
            List<ProjeKarakter> projeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(proje.Id);
            //proje = await _dal.GetAsync(i => i.GuidId.Equals(guidId));


            var tasks = projeKarakterleri.Select(async karakter =>
            {
                karakter.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(karakter.Id);
                foreach (var oyuncu in karakter.ProjeKarakterOyunculari)
                {
                    var tResim = _oyuncuResimServis.GetListAsync(i => i.OyuncuId == oyuncu.OyuncuId && i.Aktif);
                    var tVideo = _oyuncuVideoServis.GetListAsync(i => i.OyuncuId == oyuncu.OyuncuId && i.Aktif);

                    oyuncu.Oyuncu.OyuncuResimleri = await tResim;
                    oyuncu.Oyuncu.OyuncuVideolari = await tVideo;
                }
            });

            await Task.WhenAll(tasks);


            ProjeDetailDto projeDetailDto = new ProjeDetailDto
            {
                Id = proje.Id,
                GuidId = proje.GuidId,
                ProjeAdi = proje.Adi,
                ProjeTarihBas = proje.TarihBas,
                ProjeTarihBit = proje.TarihBit,
                IlgiliKisi = $"{proje.IsiTakipEden.Kisi.Adi} {proje.IsiTakipEden.Kisi.Soyadi}",
                IlgiliCep = proje.IsiTakipEden.Kisi.Cep,
                IlgiliTelefon = proje.IsiTakipEden.Kisi.Telefon,
                IlgiliEPosta = proje.IsiTakipEden.Kisi.EPosta,
                EPostaAdresleri = proje.EPostaAdresleri,
                ProjeKarakterleri = new List<ProjeKarakterDetailDto>()
            };
            foreach (var karakter in projeKarakterleri)
            {
                var karakterDetay = new ProjeKarakterDetailDto
                {
                    Id = karakter.Id,
                    Adi = karakter.Adi,
                    KarakterSayisi = karakter.KarakterSayisi,
                    Oyuncular = new List<OyuncuDetailDto>()
                };

                foreach (var oyuncu in karakter.ProjeKarakterOyunculari)
                {
                    karakterDetay.Oyuncular.Add(new OyuncuDetailDto
                    {
                        Id = oyuncu.Oyuncu.Id,
                        ProfilUrl = oyuncu.Oyuncu.Kisi.ProfilFotoUrl,
                        KarakterDurumu = oyuncu.KarakterDurumu,
                        Tc = oyuncu.Oyuncu.Kisi.TC,
                        Adi = oyuncu.Oyuncu.Kisi.Adi,
                        Soyadi = oyuncu.Oyuncu.Kisi.Soyadi,
                        Cep = oyuncu.Oyuncu.Kisi.Cep,
                        Telefon = oyuncu.Oyuncu.Kisi.Telefon.IfIsNull(oyuncu.Oyuncu.Kisi.Telefon2).IfIsNull("").ToString(),
                        Ilce = ((Ilce)oyuncu.Oyuncu.Kisi.Ilce.IfIsNull(new Ilce())).Adi,
                        Yas = (DateTime.Today.Year - oyuncu.Oyuncu.Kisi.DogumTarihi.Value.Year) - (oyuncu.Oyuncu.Kisi.DogumTarihi.Value > DateTime.Today.AddYears(-1 * (DateTime.Today.Year - oyuncu.Oyuncu.Kisi.DogumTarihi.Value.Year)) ? -1 : 0),
                        UstBeden = oyuncu.Oyuncu.UstBeden,
                        AltBeden = oyuncu.Oyuncu.AltBeden,
                        AyakNumarasi = oyuncu.Oyuncu.AltBeden,
                        Boy = oyuncu.Oyuncu.AltBeden,
                        Kilo = oyuncu.Oyuncu.AltBeden,
                        GozRengi = oyuncu.Oyuncu.GozRengi,
                        SacRengi = oyuncu.Oyuncu.SacRengi,
                        TenRengi = oyuncu.Oyuncu.TenRengi,
                        OyuculukEgitimi = oyuncu.Oyuncu.OyuculukEgitimi,
                        Tecrubeler = oyuncu.Oyuncu.Tecrubeler,
                        YabanciDil = oyuncu.Oyuncu.YabanciDil,
                        Yetenekleri = oyuncu.Oyuncu.Yetenekleri,
                        OyuncuResimleri = oyuncu.Oyuncu.OyuncuResimleri.Take(3).Select(i => i.DosyaYolu).ToList(),
                        OyuncuVideolari = oyuncu.Oyuncu.OyuncuVideolari.Take(3).Select(i => i.DosyaYolu).ToList()
                    });
                }


                projeDetailDto.ProjeKarakterleri.Add(karakterDetay);
            }



            return projeDetailDto;

        }

        public async Task<ProjeEditDto> GetEditDtoAsync(int? id, int? musteriId)
        {
            var tKul = _KullaniciServis.GetSelectListAsync();
            var tUyruk = _UyrukServis.GetSelectListAsync();
            var tIl = _IlServis.GetSelectListAsync();

            var projeEditDto = new ProjeEditDto()
            {
                Kullanicilar = await tKul,
                OyuncuFilterDto = new OyuncuFilterDto { Uyruklar = await tUyruk, Iller = await tIl }
            };

            if (id == null)
            {
                projeEditDto.Proje = new Proje
                {
                    MusteriId = musteriId.Value,
                    TarihBas = DateTime.Today,
                    TarihBit = DateTime.Today,
                    Musteri = await _MusteriServis.GetByIdAsync(musteriId.Value),
                    ProjeKarakterleri = new List<ProjeKarakter>(),
                };
            }
            else
            {
                projeEditDto.Proje = await base.GetByIdAsync(id.Value);
                projeEditDto.Proje.Musteri = await _MusteriServis.GetByIdAsync(projeEditDto.Proje.MusteriId);
                projeEditDto.Proje.ProjeKarakterleri = await _ProjeKarakterServis.GetListByProjeIdAsync(id.Value);
                foreach (var item in projeEditDto.Proje.ProjeKarakterleri)
                {
                    item.ProjeKarakterOyunculari = await _ProjeKarakterOyuncuServis.GetListByProjeKarakterIdAsync(item.Id);
                }
            }

            return projeEditDto;
        }

        public override async Task UpdateAsync(Proje entity, UserHelper userHelper)
        {
            var t1 = base.UpdateAsync(entity, userHelper);
            var t2 = Save_ProjeKarakterAsync(entity, userHelper);
            await Task.WhenAll(t1, t2);
        }

        private async Task Save_ProjeKarakterAsync(Proje entity, UserHelper userHelper)
        {
            if (entity.ProjeKarakterleri != null)
            {
                var t = new Task[entity.ProjeKarakterleri.Count];
                foreach (var item in entity.ProjeKarakterleri)
                {
                    item.ProjeId = entity.Id;
                    t[entity.ProjeKarakterleri.IndexOf(item)] = _ProjeKarakterServis.SaveAsync(item, userHelper);
                }
                await Task.WhenAll(t);
            }
            else
            {
                await Task.CompletedTask;
            }
        }

        public void Pdf()
        {
            //string linki = Link;
            var Renderer = new IronPdf.HtmlToPdf();
            var Link = "http://localhost:51264/Projeler/Detail/867b2994-1078-4e1b-90f9-be9a67a58193";
            var PDF = Renderer.RenderUrlAsPdf(Link);
            PDF.SaveAs(@"C:\Test\isimkoy.pdf");
            // This neat trick opens our PDF file so we can see the result
            //System.Diagnostics.Process.Start(@"C:\Test\isimkoy.pdf");            

        }



        //public override async Task<Proje> GetByIdAsync(int id)
        //{
        //    return await _dal.GetAsync(new List<string> { "ProjeKarakter" }, (x => x.Id == id));           
        //}
    }
}
