using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCookieAuthSample.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
namespace MVCCookieAuthSample.Controllers
{

    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var claims =new List<Claim>{
                new Claim(ClaimTypes.Name ,"zhangshuai"),
                new Claim(ClaimTypes.Role ,"admin")
            };
            var claimIdentity =new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal (claimIdentity));
            
            return Ok("Login");
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);  
            return Ok("LoginOut");
        }
    }
}
