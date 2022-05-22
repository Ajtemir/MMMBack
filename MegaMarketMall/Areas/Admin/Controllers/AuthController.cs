using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Extensions;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]")]
    public class AuthController : Controller
    {
        private readonly IUserService _user;

        public AuthController(IUserService user)
        {
            _user = user;
        }

        [HttpGet("[action]")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginAdminViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _user.GetUserByEmailAsync(model.Email);
            
            if (user == null)
            {
                ModelState.AddModelError("Email","User with this email not found");
                return View(model);
            }
            if (user.Role is UserRoles.User or UserRoles.Seller)
            {
                ModelState.AddModelError("","Permission denied you are not administrator");
                return View(model);
            }
            if (!user.CheckPassword(model.Password))
            {
                ModelState.AddModelError("Password","Password is not correct");
                return View(model);
            }

            

            
            await AuthenticateAsync(user);
            return RedirectToAction("Index", "Home");
        }
        
        
        [HttpGet("[action]")]
        public new async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        // [HttpGet("[action]")]
        // [Authorize("OnlyForOwner")]
        // public async Task<IActionResult> Signup()
        // {
        //     return View();
        // }
        //
        // [HttpPost("[action]")]
        // [Authorize("OnlyForOwner")]
        // public async Task<IActionResult> Signup(AdminViewModel model)
        // {
        //     if (!await _user.ContainsEmailAsync(model.Email))
        //     {
        //         ModelState.AddModelError("Email", "Such email has already been insisted");
        //         return View(model);
        //     }
        //     if (!ModelState.IsValid) return View();
        //     await _user.CreateAdminAsync(model);
        //     return View();
        // }
        
        
        
        private async Task AuthenticateAsync(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
                
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", 
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
    
    
}