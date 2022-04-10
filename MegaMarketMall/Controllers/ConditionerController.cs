using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Data.Filters.Product;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Repository;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConditionerController : ControllerBase
    {
        private readonly IRepository<Conditioner> _repository;
        private readonly IConditionerService _conditioner;
        public ConditionerController(IRepository<Conditioner> repository, IConditionerService conditioner)
        {
            _repository = repository;
            _conditioner = conditioner;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conditioner>>> Get([FromQuery]ConditionerGet query)
        {
            var conditioners = _repository.Filter(query);
            var filtered = await _conditioner.FilterAsync(conditioners, query);
            var result = await _repository.PaginateAsync(filtered, query);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult<Conditioner>> Create([FromForm]ConditionerPost conditioner)
        {
            await _conditioner.CreateAsync(conditioner);
            return Created("created",conditioner);
        }

        [HttpPut]
        [TypeFilter(typeof(ProductSellerAttribute))]
        public async Task<ActionResult<Conditioner>> Update([FromQuery] int id,[FromBody] ConditionerPut data)
        {
            await _conditioner.UpdateAsync(id, data);
            return Ok();
        }
    }
}