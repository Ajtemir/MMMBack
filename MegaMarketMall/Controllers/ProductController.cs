using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MegaMarketMall.Data.Filters.Product;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Local.Product;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Repository;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRepository<Product> _repository;
        private readonly IProductPhotoService _photo;
        
        public ProductController(IProductService productService, IRepository<Product> repository, IProductPhotoService photo)
        {
            _productService = productService;
            _repository = repository;
            _photo = photo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]ProductGet query)
        {
            var products = _productService.Filter(query);
            var response = await _productService.Paginate(products, query.Page);
            return Ok(response);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return BadRequest();
            return Ok(product);
        }

        [Authorize(Roles = "Seller")]
        [TypeFilter(typeof(ProductSellerAttribute))]
        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct([FromQuery]int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return BadRequest("Not Found Such Product For Deleting");
            product.IsDeleted = true;
            await _productService.UpdateAsync(product);
            return Ok(product);
        }

        [HttpPatch]
        [Authorize(Roles = "Seller")]
        [TypeFilter(typeof(ProductSellerAttribute))]
        public async Task<ActionResult> PatchPhotos([Required]int id,[FromForm] PatchPhoto data)
        {
            if (data.AddedPhotos is not null)
                await _photo.CreatePhotosAsync(data.AddedPhotos,id);
            if (data.RemovedPhotos is not null)
                await _photo.DeletePhotosAsync(data.RemovedPhotos, id);
            return Ok();
        }

        [HttpPost]
        // [Authorize(Roles = "Seller")]
        public async Task<ActionResult> CreatePhoto([FromForm]PostPhoto data)
        {
            if (data.AddedPhotos is not null)
            {
                var ids = await _photo.CreatePhotosAsync(data.AddedPhotos);
                return Ok(ids);
            }

            return BadRequest();

        }
    }
}