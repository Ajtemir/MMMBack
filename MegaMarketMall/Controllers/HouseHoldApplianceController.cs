using System.Threading.Tasks;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances;
using MegaMarketMall.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseHoldApplianceController : ControllerBase
    {
        private readonly IRepository<HouseHoldAppliance> _repository;

        public HouseHoldApplianceController(IRepository<HouseHoldAppliance> repository)
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