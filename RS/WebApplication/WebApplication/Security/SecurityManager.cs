using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Security
{
    public class SecurityManager
    {
        public async void SignIn(HttpContext httpContext, Account account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(getUserClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        private IEnumerable<Claim> getUserClaims(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            claims.Add(new Claim(ClaimTypes.Role, account.Role.Name));
            return claims;
        }
    }
}
