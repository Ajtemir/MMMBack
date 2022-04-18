using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Services.CategoryService;
using MegaMarketMall.TestData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Controllers
{
    public class OtherController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryService _category;

        public OtherController(ApplicationContext context, IMapper mapper, ICategoryService category)
        {
            _context = context;
            _mapper = mapper;
            _category = category;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetByQuery([FromQuery]ProductGet query)
        {
            _context.OwnerTests.Add(new OwnerTest
            {
                Id = 1,
                Name = null,
                RName = "fgdf",
                LastName = "fgd",
                RLastName = "gsfgd",
                Username = null,
                Age = 29,
                Patronymic = null,
                Status = null,
                Account = 444,
                Bought = 1000
            });
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Conditioner>> Conditioners([FromForm]Conditioner conditioner)
        {
            await _context.Conditioners.AddAsync(conditioner);
            await _context.SaveChangesAsync();
            return Ok(conditioner);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Conditioner>> Conditioners([FromQuery]int id, Conditioner conditioner)
        {
            conditioner.Id = id;
            _context.Conditioners.Update(conditioner);
            await _context.SaveChangesAsync();
            return Ok(conditioner);
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult<ProductTest>> ProductTestPost([FromBody]ProductTest user)
        {
            if (ModelState.IsValid)
            {
                await _context.ProductTests.AddAsync(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }

            return BadRequest(ModelState);

        }

        [HttpGet("[action]")]
        public ActionResult<ProductTest> ProductGet()
        {
            var product = _context.ProductTests.OrderBy(p=>p.Id).Last();
            return Ok(product);
        }

        [HttpPost("[action]")]
        public ActionResult<MapObjectTo> CheckMapper()
        {
            
            var from = new MapObject()
            {
                Id = 5,
                Name = 20
            };
            var obj = _mapper.Map<MapObject, MapObjectTo>(from);
            Console.WriteLine(obj.Id);
            return Ok(obj);
        }
        
        [HttpPost("[action]")]
        public async Task<ActionResult<MapObjectTo>> CreateShopper(ConditionerGet query)
        {
            
            // var queryable = _context.Products.Where(product => ((SewingMachine)product).Id==4 | (product as Conditioner).BrandId==1).Select(product => new
            // {
            //     ыапрва=product.Id,
            //     sfg=new
            //     {
            //         dsg=product.Favorites,
            //         gsfgdf=product.Views
            //     }
            // });
            
            
            
            // var queryable = _context.Products.Where(p => (p as Conditioner).BrandId==1 || (p as WristWatch).BrandId ==1).Select(p=>new
            // {
            //     id= p.Id
            //     
            // }).ToList();

            var queryable = await _category.GetLowestSubCategoriesIdAsync(2);
            queryable.ForEach(id=>Console.WriteLine(id));
            
            
            return Ok(queryable);
        }
        
        
        [HttpGet("[action]")]
        public ActionResult<ProductTest> ProductGetAddition()
        {
            var product = _context.Products.FindAsync(1).Result;
            return Ok(product);
        }

    }
}