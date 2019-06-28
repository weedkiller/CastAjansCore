using Calbay.Core.Business;
using Calbay.Core.Entities;
using Calbay.Core.Helper;
using CastAjansCore.Business.Abstract;
using CastAjansCore.Business.Concrete;
using CastAjansCore.DataLayer.Abstract;
using CastAjansCore.DataLayer.Concrete.EntityFramework;
using CastAjansCore.Dto;
using CastAjansCore.WebUI.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;

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
            services.AddMvc(
                options =>
                {
                    var F = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                    var L = F.Create("ModelBindingMessages", "CastAjansCore.WebUI");
                    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                        (x) => L["Değer '{0}' geçerli değil."]);
                    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
                        (x) => L["Alan {0} numara olmalıdır."]);
                    options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(
                        (x) => L["A value for the '{0}' property was not provided.", x]);
                    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                        (x, y) => L["The value '{0}' is not valid for {1}.", x, y]);
                    options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
                        () => L["A değer gereklidir."]);
                    options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(
                        (x) => L[" {0} değer geçersiz.", x]);
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        (x) => L["Boş değer geçersiz.", x]);
                })
                .AddDataAnnotationsLocalization()
                .AddViewLocalization();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Kullanicilar/Login/";
                options.AccessDeniedPath = "/Kullanicilar/AccessDenied/"; 
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("tr") };
                options.DefaultRequestCulture = new RequestCulture("tr", "tr");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            }); ;
            services.AddSession();
            services.AddMemoryCache();

            services.Configure<EmailSettings>(_configuration.GetSection("EmailSettings"));
            services.Configure<ParamereSettings>(_configuration.GetSection("ParamereSettings"));


            AddScoped(services);

            var cultureInfo = new CultureInfo("tr-TR");
            cultureInfo.NumberFormat.CurrencySymbol = "₺";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }

        private void AddScoped(IServiceCollection services)
        {

            //services.AddScoped<IAdresDal, EfAdresDal>();
            //services.AddSingleton<IHostingEnvironment>(new HostingEnvironment());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<LoginHelper>();
            services.AddSingleton<IEmailServis, EmailServis>();

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

            services.AddSingleton<IUyrukServis, UyrukManager>();
            services.AddSingleton<IUyrukDal, EfUyrukDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("tr") };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("tr")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseStaticFiles();

            env.EnvironmentName = EnvironmentName.Development;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //app.UseStaticFiles(new StaticFileOptions()
                //{
                //    FileProvider = new PhysicalFileProvider(
                //    Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                //    RequestPath = new PathString("/vendor")
                //});
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
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
