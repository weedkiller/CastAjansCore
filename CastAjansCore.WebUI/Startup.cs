using CastAjansCore.Business.Abstract;
using CastAjansCore.Business.Concrete;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace CastAjansCore.WebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();


            services.AddSession();
            services.AddMemoryCache();

            AddScoped(services);
        }

        private void AddScoped(IServiceCollection services)
        {
            services.AddSingleton<IAdresServis, AdresManager>();
            services.AddSingleton<IAdresDal, EfAdresDal>();
            //services.AddScoped<IAdresDal, EfAdresDal>();
            
            services.AddSingleton<IBankaServis, BankaManager>();
            services.AddSingleton<IBankaDal, EfBankaDal>();

        

            services.AddSingleton<IProjeKarakterServis, ProjeKarakterManager>();
            services.AddSingleton<IProjeKarakterManagerDal, EfProjeKarakterDal>();

            services.AddSingleton<IProjeKarakterOyuncuServis, BolumKarakterOyuncuManager>();
            services.AddSingleton<IProjeKarakterOyuncuDal, EfProjeKarakterOyuncuDal>();

            services.AddSingleton<IFirmaServis, FirmaManager>();
            services.AddSingleton<IFirmaDal, EfFirmaDal>();

            services.AddSingleton<IIlServis, IlManager>();
            services.AddSingleton<IIlDal, EfIlDal>();

            services.AddSingleton<IIlceServis, IlceManager>();
            services.AddSingleton<IIlceDal, EfIlceDal>();

            services.AddSingleton<IKisiServis, KisiManager>();
            services.AddSingleton<IKisiDal, EfKisiDal>();

            services.AddSingleton<IKisiBankaServis, KisiBankaManager>();
            services.AddSingleton<IKisiBankaDal, EfKisiBankaDal>();

            services.AddSingleton<IKullaniciServis, KullaniciManager>();
            services.AddSingleton<IKullaniciDal, EfKullaniciDal>();

            services.AddSingleton<IKullaniciServis, KullaniciManager>();
            services.AddSingleton<IKullaniciDal, EfKullaniciDal>();

            services.AddSingleton<IMusteriServis, MusteriManager>();
            services.AddSingleton<IMusteriDal, EfMusteriDal>();

            services.AddSingleton<IOyuncuServis, OyuncuManager>();
            services.AddSingleton<IOyuncuDal, EfOyuncuDal>();

            services.AddSingleton<IOyuncuResimServis, OyuncuResimManager>();
            services.AddSingleton<IOyuncuResimDal, EfOyuncuResimDal>();

            services.AddSingleton<IOyuncuVideoServis, OyuncuVideoManager>();
            services.AddSingleton<IOyuncuVideoDal, EfOyuncuVideoDal>();

            services.AddSingleton<IProjeServis, ProjeManager>();
            services.AddSingleton<IProjeDal, EfProjeDal>();

 

            services.AddSingleton<ITelefonServis, TelefonManager>();
            services.AddSingleton<ITelefonDal, EfTelefonDal>();

            services.AddSingleton<IUyrukServis, UyrukManager>();
            services.AddSingleton<IUyrukDal, EfUyrukDal>();

 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                    RequestPath = new PathString("/vendor")
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();
            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {            
            routeBuilder.MapRoute(name: "default", template: "{controller=home}/{action=index}/{id?}");

            routeBuilder.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
