using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationContext _context;

        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetLowestSubCategoriesAsync(Category category)
        {
            List<Category> categories = new();
            Queue<Category> queue = new();
            queue.Enqueue(category);
            while (queue.Any())
            {
                Category current = queue.Dequeue();
                await _context.Categories.Where(c=>c.ParentCategoryId == current.Id).LoadAsync();
                if (current.SubCategories.Any())
                    foreach (var subCategory in current.SubCategories)
                        queue.Enqueue(subCategory);
                else
                    categories.Add(current);
            }
            categories.Remove(category);
            return categories;
        }

        public async Task<List<int>> GetLowestSubCategoriesIdAsync(int categoryId)
        {
            List<int> categories = new();
            Queue<Category> queue = new();
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category is null) return null;

            queue.Enqueue(category);
            while (queue.Any())
            {
                Category current = queue.Dequeue();
                await _context.Categories.Where(c=>c.ParentCategoryId == current.Id).LoadAsync();
                if (current.SubCategories.Any())
                    foreach (var subCategory in current.SubCategories)
                        queue.Enqueue(subCategory);
                else
                    categories.Add(current.Id);
            }
            categories.Remove(category.Id);
            return categories;
        }
    }
}