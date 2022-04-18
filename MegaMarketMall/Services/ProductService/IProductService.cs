using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response;
using MegaMarketMall.Dtos.Response.ProductView;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Services.ProductService
{
    public interface IProductService
    { 
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
        IQueryable<Product> Filter(ProductGet query);
        IQueryable<Product> Filter(IQueryable<Product> products,ProductGet query);
        Task<IQueryable<Product>> FilterByParentCategoryIdAndQueriesAsync(ProductGet query,int parentCategoryId);
        Task<IQueryable<Product>> FilterByParentCategoryIdAsync(IQueryable<Product> products,int parentCategoryId);
        Task<QueryResponse<Product>> PaginateAsync(IQueryable<Product> products, IPage pages);
        Task<ProductViewResponse> PaginateProductViewsAsync(IQueryable<Product> products, IPage pages);
        Task<List<ProductView>> ToListProductViewsAsync(IQueryable<Product> products);

        
        void MapProduct(Product product, BaseProductPut putData);



    }
}