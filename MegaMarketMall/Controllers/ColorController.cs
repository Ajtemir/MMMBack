using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Models.Colors;
using MegaMarketMall.Services.ColorService;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController :ControllerBase
    {
        private readonly IColorService _color;
        public ColorController(IColorService color) => _color = color;
        [HttpGet("[action]")] public async Task<ActionResult<List<WristWatchColor>>> WristWatch() => Ok(await _color.GetColorsAsync<WristWatchColor>());
    }
}