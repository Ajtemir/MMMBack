using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Extensions
{
    public static class CategoryExtension
    {
        public static async Task<List<Category>> GetLowestSubCategories(this Category category, ApplicationContext db)
        {
            List<Category> categories = new();
            Queue<Category> queue = new();
            queue.Enqueue(category);
            while (queue.Any())
            {
                Category current = queue.Dequeue();
                await db.Categories.Where(c=>c.ParentCategoryId == current.Id).LoadAsync();
                if (current.SubCategories.Any())
                {
                    foreach (var subCategory in current.SubCategories)
                    {
                        queue.Enqueue(subCategory);
                    }
                }
                else
                {
                    categories.Add(current);
                }
            }
            categories.Remove(category);
            return categories;
        }
    }
}