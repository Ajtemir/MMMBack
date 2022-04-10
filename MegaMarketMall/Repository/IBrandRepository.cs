using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;

namespace MegaMarketMall.Repository
{
    // public interface IBrandRepository<T, TT>
    public interface IBrandRepository<TEntity, TT> where TEntity:Brand
    {
        public Task MapBrandAsync(IBrandFk property, string brandName);
        public Task<int?> GetBrandIdAsync(string brandName);
        Task<IQueryable<IBrandFk>> FilterBrandAsync(IQueryable<IBrandFk> products, IBrandGet query);
        
    }
}