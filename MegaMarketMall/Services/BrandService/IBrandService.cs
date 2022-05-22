using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Dtos.Response.BrandView;
using MegaMarketMall.Models.Brands;

namespace MegaMarketMall.Services.BrandService
{
    public interface IBrandService
    {
        Task<List<BrandView>> GetBrandAsync<T>() where T : Brand;
    }
}