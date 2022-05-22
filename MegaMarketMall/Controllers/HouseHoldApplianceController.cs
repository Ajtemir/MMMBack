using System.Threading.Tasks;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseHoldApplianceController : ControllerBase
    {
        private readonly IProductService _product;

        public HouseHoldApplianceController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]ProductGet query)
        {
            var filtered =
                await _product.FilterByParentCategoryIdAndQueriesAsync(query, CategoryConstants.HouseHoldAppliances);
            var result = await _product.PaginateAsync(filtered,query);
            return Ok(result);
        }
    }
}