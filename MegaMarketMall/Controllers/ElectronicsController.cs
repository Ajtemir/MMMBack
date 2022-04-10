using System.Threading.Tasks;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Get.Cluster.Electronics;
using MegaMarketMall.Models.Products.Cluster.Electronics;
using MegaMarketMall.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ElectronicsController : ControllerBase
    {
        private readonly IRepository<Electronic> _repository;

        public ElectronicsController(IRepository<Electronic> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]ProductGet query)
        {
            var filtered = _repository.Filter(query);
            var result = await _repository.PaginateAsync(filtered, query);
            return Ok(result);
        }
        
    }
}