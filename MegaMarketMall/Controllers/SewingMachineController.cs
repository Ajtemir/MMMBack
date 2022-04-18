using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JsonPatch.Restrict;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Filters.Product;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Dtos.Get.Cluster;
using MegaMarketMall.Dtos.Patch;
using MegaMarketMall.Dtos.Post;
using MegaMarketMall.Dtos.Put.Cluster;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Repository;
using MegaMarketMall.Services;
using MegaMarketMall.Services.Cluster.SewingMachineService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SewingMachineController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository<SewingMachine> _repository;
        private readonly ISewingMachineService _sewingMachineService;
        private readonly IProductPhotoService _photo;


        public SewingMachineController(ApplicationContext context, IMapper mapper, IRepository<SewingMachine> repository, ISewingMachineService sewingMachineService, IProductPhotoService photo)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
            _sewingMachineService = sewingMachineService;
            _photo = photo;
        }

        [HttpGet]
        public async Task<ActionResult<List<SewingMachine>>> Get([FromQuery]SewingMachineGet query)
        {
            var products = _repository.Filter(query);
            var filtered = _sewingMachineService.Filter(products, query);
            var result = await _repository.PaginateAsync(filtered, query);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<SewingMachine>> Post([FromForm] SewingMachinePost data)
        {
            var product = await _sewingMachineService.CreateAsync(data);
            return Ok(product);
        }

        

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<SewingMachine> patch)
        {   
            var product = await _context.SewingMachines.FirstOrDefaultAsync(p => p.Id == id);
            var allowedProperties = new []{"SellerId", "Price"};
            if (!patch.TryApplyToWithRestrictions(product,out var error,allowedProperties))
                return BadRequest(error);
            patch.ApplyToWithRestrictions(product,allowedProperties);
            _context.Update(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return Ok(patch);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SewingMachine>> Put(int id, SewingMachinePut put)
        {
            var obj = await _context.SewingMachines.FirstOrDefaultAsync(p=>p.Id==id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _mapper.Map(put, obj);
            _context.SewingMachines.Update(product);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(new []{obj,product});
        }
    }
}