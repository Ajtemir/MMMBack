using System.Threading.Tasks;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Response;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;
using MegaMarketMall.Repositories;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WashingMachineController : ControllerBase
    {
        private readonly IRepository<WashingMachine> _repository;
        private readonly IWashingMachineService _washingMachine;

        public WashingMachineController(IRepository<WashingMachine> repository, IWashingMachineService washingMachine)
        {
            _repository = repository;
            _washingMachine = washingMachine;
        }

        [HttpGet]
        public async Task<ActionResult<QueryResponse<WashingMachine>>> Get([FromQuery] WashingMachineGet query)
        {
            var products = _repository.Filter(query);
            var filtered =  _washingMachine.Filter(products, query);
            var result = await _repository.PaginateAsync(filtered, query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<WashingMachine>> Post([FromForm] WashingMachinePost data)
        {
            await _washingMachine.CreateAsync(data);
            return Created("created",data);
        }

    }
}