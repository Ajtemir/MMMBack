using System.Threading.Tasks;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {
        private readonly IProductService _product;

        public ElectronicsController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<ActionResult> GetView([FromQuery]ProductGet query)
        {
            var filtered = await _product.FilterByParentCategoryIdAndQueriesAsync(query, CategoryConstants.Electronics);
            var result = await  _product.PaginateProductViewsAsync(filtered, query);
            // var result = await _product.PaginateAsync(filtered, query);
            return Ok(result);
        }
        
    }
}