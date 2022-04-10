using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Extensions;
using MegaMarketMall.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoryController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]        
        public async Task<IActionResult> AllCategories()
        {
            var response = await _context.Categories.ToListAsync();
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AllLowestSubCategories([FromQuery] string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
            if (category is null)
                return BadRequest("Wrong Category Name");
            return Ok(await category.GetLowestSubCategories(_context));
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> AllSubCategories([FromQuery] string name)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c=>c.Name==name);
            if (category is null)
                return BadRequest("Wrong Category Name");
            await _context.Categories.Where(c => c.ParentCategoryId == category.Id).LoadAsync();
            return Ok(category.SubCategories);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory([FromQuery] string name, [FromQuery] string parentName)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Category name mustn't be null or not be empty");
            if (_context.Categories.Any(c => c.Name == name))
                return BadRequest("Category is consist and so rename category name");
            var parentCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Name == parentName);
            if (parentCategory is null)
                return BadRequest("Parent category does not consist");
            Category category = new(){Name = name, ParentCategoryId = parentCategory.Id};
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<Category>>> GetAllLowestCategories()
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c=>c.Name=="all");
            var categories = await category.GetLowestSubCategories(_context);
            return Ok(categories);
        }
        
       



    }
}