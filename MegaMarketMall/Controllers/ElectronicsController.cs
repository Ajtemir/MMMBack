using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Repositories;
using MegaMarketMall.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {
        private readonly IProductService _product;

        public ElectronicsController(IProductService product) => _product = product;
        

        [HttpGet]
        public async Task<ActionResult<QueryResponse<Product>>> Get([FromQuery]ProductGet query)
        {
            var filtered = await _product.FilterByParentCategoryIdAndQueriesAsync(query, CategoryConstants.Electronics);
            var result = await  _product.PaginateAsync(filtered, query);
            return Ok(result);
        }
    }
}