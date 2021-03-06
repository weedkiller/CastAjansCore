using Calbay.Core.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Helper
{
    public class LoginHelper
    {

        private readonly IHttpContextAccessor _httpContextAccessor;


        public LoginHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;            
        }

        public async Task Login(UserHelper kullanici)
        {
            //HttpContext.Session.SetUserHelper(kullanici);

            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, kullanici.KullaniciAdi),
                    new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                    new Claim(ClaimTypes.Surname, kullanici.Soyadi),
                    new Claim(ClaimTypes.Role, kullanici.Rol.ToString()),
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(kullanici)),
                    new Claim(ClaimTypes.Role,kullanici.Rol.ToString())
                };
            //RemoveCookie("login");
            var userIdentity = new ClaimsIdentity(claims, "login1");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,                
                //ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                ExpiresUtc = DateTime.UtcNow.AddYears(1),
                IsPersistent = true
            };

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,                
                authProperties);
        }

        public void RemoveCookie(string cookieName)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName, "", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(-1)
            });
        }

        public UserHelper UserHelper
        {
            get
            {            
                var u = _httpContextAccessor.HttpContext.Session.GetObject<UserHelper>("UserHelper");
                var cookiData = JsonConvert.DeserializeObject<UserHelper>(GetUserData()??"");
               
                //if (u == null)
                //{
                //    var user = _kullaniciServis.GetById(id);

                //    u = _kullaniciServis.get
                //    _httpContextAccessor.HttpContext.Session.SetUserHelper(u);
                //}
                return cookiData;
            } 
        }

        //public string GetUserId()
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        //    var userId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
        //    return userId;
        //}
        //public string GetUserName()
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        //    var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();
        //    return name;
        //}
        //public string GetUserMail()
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
        //    var mail = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
        //    return mail;
        //}

        public string GetUserData()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var principal = Thread.CurrentPrincipal as ClaimsPrincipal;
            var userdata = _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.UserData).Select(c => c.Value).FirstOrDefault();
            return userdata;
        }
    }
}
