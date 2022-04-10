using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery] int id)
        {
            Console.WriteLine(id);
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AllCategories()
        {
            var allCategories = await _context.Categories.ToListAsync();
            
            return Ok(allCategories);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddTestUser(UserTest user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _context.UserTests.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetUser()
        {
            return Ok(await _context.UserTests.FirstOrDefaultAsync(u=>u.Id==1));
        }
    }
}