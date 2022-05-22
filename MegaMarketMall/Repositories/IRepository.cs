using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Repositories
{
    public interface IRepository<TEntity> where TEntity:Product
    {
        IQueryable<TEntity> Filter(ProductGet query);
        
        Task<QueryResponse<TEntity>> PaginateAsync(IQueryable<TEntity> products, IPage page);
        IQueryable<TEntity> Paginate(IQueryable<TEntity> products, IPage page);
        Task<QueryResponse<TEntity>> ToListAsync(IQueryable<TEntity> products,IPage page);
        Task DeletePhotos(TEntity product, IPhotoDelete deletedPhotoNames);
    }
}