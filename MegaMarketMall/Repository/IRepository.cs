using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Repository
{
    public interface IRepository<TEntity> where TEntity:class,IEntity
    {
        IQueryable<TEntity> Filter(ProductGet query);
        Task<QueryResponse<TEntity>> PaginateAsync(IQueryable<TEntity> products, IPage page);
        Task DeletePhotos(TEntity product, IPhotoDelete deletedPhotoNames);
    }
}