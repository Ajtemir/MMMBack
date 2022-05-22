using System;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Methods;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        [HttpGet("{param:alpha}")]
        public ActionResult GetProperties([FromRoute]string param)
        {
            var data = ProductAttributeConstants.DictEnums;
            if (data.TryGetValue(param, out var type))
            {
                var response = EnumToDict.ConvertEnumToDict<Enum>(type);
                return Ok(response);
            }
            else return BadRequest("No Such Parameters group");
        }
    }
}