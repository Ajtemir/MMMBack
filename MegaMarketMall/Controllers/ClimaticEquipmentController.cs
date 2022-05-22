using System.Threading.Tasks;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClimaticEquipmentController : ControllerBase
    {
        private readonly IProductService _product;

        public ClimaticEquipmentController(IProductService product)
        {
            _product = product;
        }
        
        [HttpGet]
        public async Task<ActionResult<QueryResponse<Product>>> Get([FromQuery]ProductGet query)
        {
            var filtered = await _product.FilterByParentCategoryIdAndQueriesAsync(query, CategoryConstants.HouseHoldAppliances);
            var result = await  _product.PaginateAsync(filtered, query);
            return Ok(result);
        }
    }
}