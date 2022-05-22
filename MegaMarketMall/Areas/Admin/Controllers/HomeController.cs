using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]")]
    [Authorize(AuthenticationSchemes=CookieAuthenticationDefaults.AuthenticationScheme,Policy = "OnlyForAdmin")]
    public class HomeController : Controller
    {
        private readonly IProductService _product;

        public HomeController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _product.GetProducts().ToListAsync();
            return View(products);
        }
        
        
        
    }
}