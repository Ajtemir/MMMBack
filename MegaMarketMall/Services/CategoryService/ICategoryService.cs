using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Models.Categories;

namespace MegaMarketMall.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetLowestSubCategoriesAsync(Category category);
        Task<List<int>> GetLowestSubCategoriesIdAsync(int categoryId);
    }
}