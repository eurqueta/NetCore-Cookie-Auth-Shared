using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication3.Areas.Identity
{
    public class UserConfigurator
    {

        string _connectionString;
        public UserConfigurator(string connectionString)
        {
            _connectionString = connectionString;
        }



        public async void SignIn(HttpContext httpContext,  bool isPersistent = false)
        {


                ClaimsIdentity identity = new ClaimsIdentity(GetUserClaims() ,CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            
        }

        public async Task SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, "eurqueta"));
            claims.Add(new Claim(ClaimTypes.Name, "Eduardo"));
            claims.Add(new Claim(ClaimTypes.Email, "eduardo@gmail.com"));
            claims.AddRange(this.GetUserRoleClaims());
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, "eurqueta"));
            claims.Add(new Claim(ClaimTypes.Role, "rol"));
            return claims;
        }


    }
}
