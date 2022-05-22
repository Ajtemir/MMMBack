using System.Threading.Tasks;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Services.BrandService;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")] 
    [ApiController]
    public class BrandController : ControllerBase
    {
        private static IBrandService _brand;
        public BrandController(IBrandService brand) => _brand = brand;
        [HttpGet("[action]")] public async Task<ActionResult> Conditioner() => Ok(await _brand.GetBrandAsync<ConditionerBrand>());
    }
}