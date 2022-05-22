using System.Threading.Tasks;
using MegaMarketMall.Areas.Admin.ViewModels;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Repositories.AdminRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MegaMarketMall.Areas.Admin.Controllers
{
    [Area(AreasConstants.Admin)]
    [Route("[area]/[controller]")]
    [Authorize(AuthenticationSchemes=CookieAuthenticationDefaults.AuthenticationScheme,Policy = "OnlyForOwner")]

    public class AdminsController : Controller
    {
        private readonly IAdminRepository _admin;
        

        public AdminsController(IAdminRepository admin)
        {
            _admin = admin;
        }

        [HttpGet]
        public async Task<IActionResult> AllAdmin()
        {
            var admins = await _admin.GetAllAsync();
            return View(admins);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _admin.DeleteAsync(id);
            return RedirectToAction("AllAdmin");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Register()
        {
            return View();
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterAdminViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            if (await _admin.ConsistsAsync(model.Email))
            {
                ModelState.AddModelError("Email","this email has already been used");
                return View(model);
            }
            await _admin.CreateAsync(model);
            ViewBag.Success = "Admin has been created successfully";
            return View(model);
        }


    }
}