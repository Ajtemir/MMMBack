using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Filters.Product;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put;
using MegaMarketMall.Dtos.Response.BrandView;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Repositories;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConditionerController : ControllerBase
    {
        private readonly IRepository<Conditioner> _repository;
        private readonly IConditionerService _conditioner;
        private readonly ApplicationContext _context;
        public ConditionerController(IRepository<Conditioner> repository, IConditionerService conditioner, ApplicationContext context)
        {
            _repository = repository;
            _conditioner = conditioner;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conditioner>>> Get([FromQuery]ConditionerGet query)
        {
            var conditioners = _repository.Filter(query);
            var filtered = _conditioner.Filter(conditioners, query);
            var result = await _repository.PaginateAsync(filtered, query);
            return Ok(result);
        }

        [HttpPost]
        // [Authorize(Roles = "Seller")]
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
        
        // Properties for post request
        [HttpGet("params/{property:alpha}")]
        public ActionResult GetPropertiesOfProductChoicesFromEnum([FromRoute]string property)
        {
            var data = ProductAttributeConstants.DictEnums;
            if (data.TryGetValue(property, out var type))
            {
                var response = EnumToDict.ConvertEnumToDict<Enum>(type);
                return Ok(response);
            }
            else return BadRequest("No Such Parameters group");
        }
        
        

        
    }
}