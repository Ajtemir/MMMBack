using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Products;
using Microsoft.EntityFrameworkCore;
using IBrandGet = MegaMarketMall.Data.Interfaces.Get.IBrandGet;

namespace MegaMarketMall.Repository
{
    // public class BrandRepository<T,TT>:IBrandRepository<T,TT> where T : class,IProductBrand<TT>
    public class BrandRepository<TEntity,TT>:IBrandRepository<TEntity,TT> where TEntity: Brand
    { 
        private readonly ApplicationContext _context;

        public BrandRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task MapBrandAsync(IBrandFk property, string brandName)
        {
            if (brandName is null)
                return;
            var brandId = await GetBrandIdAsync(brandName);
            if (brandId is null)
                return;
            property.BrandId = brandId;
        }

        public async Task<int?> GetBrandIdAsync(string brandName)
        {
            var brand = await _context.Set<TEntity>().FirstOrDefaultAsync(b=>b.Name==brandName);
            return brand?.Id;
        }


        // public async Task<int?> GetBrandIdAsync(string brandName)
        // {
        //     var brand = await _context.Set<T>().FirstOrDefaultAsync(b=>b.Name==brandName);
        //     return brand?.Id;
        // }

        public async Task<IQueryable<IBrandFk>> FilterBrandAsync(IQueryable<IBrandFk> products,IBrandGet query)
        {
            // if (query.BrandId is null)
            //     return products;
            // var brandId = await GetBrandIdAsync(BrandId);
            if (query.BrandId is null)
                return products;
            products = products.Where(p => p.BrandId == query.BrandId);
            return products;



        }
    }
}