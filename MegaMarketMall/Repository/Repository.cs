using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Repository
{
    
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class,IEntity
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context) => _context = context;
        

        public IQueryable<TEntity> Filter(ProductGet query)
        {
            var products = _context.Set<TEntity>().AsQueryable();
            if (query.FromPrice is not null)
                products = products.Where(p => p.Price >= query.FromPrice);
            if (query.ToPrice is not null)
                products = products.Where(p => p.Price <= query.ToPrice);
            if (!string.IsNullOrEmpty(query.Text))
                products = products.Where(p => p.Description.Contains(query.Text));
            if (query.Deliver is null)
                products = products.Where(p => p.IsDelivered == null);
            else if (query.Deliver.Value)
                products = products.Where(p => p.IsDelivered == true);
            else 
                products = products.Where(p => p.IsDelivered == false);
            
            products = query.SortBy switch
            {
                "newest" => products
                    .OrderByDescending(p => p.TimeStamp),
                "ascending" => products.OrderBy(p => p.Price),
                "descending" => products.OrderByDescending(p => p.Price),
                _ => products.OrderBy(p=>p.TimeStamp)
            };
            return products;
        }
        
        public async Task<QueryResponse<TEntity>> PaginateAsync(IQueryable<TEntity> products, IPage pages)
        {
            var page = pages.Page;
            page ??= 1;
            page = page > 0 ? page : 1;
            const float pageResult = 4F;
            var pageCount = await products.CountAsync();
            var result = await products
                .Include(p=>p.Photos.Where(o=>o.IsDeleted==false))
                .Skip(((page.Value - 1) * (int)pageResult))
                .Take((int)pageResult)
                .ToListAsync(); 
            
            return new QueryResponse<TEntity>()
            {
                Products = result,
                CurrentPage = page.Value,
                Pages = pageCount
            };
        }

        public async Task DeletePhotos(TEntity product, IPhotoDelete deletedPhotoNames)
        {
            // foreach (var photoName in deletedPhotoNames.PhotosHaveToDelete)
            //     foreach (var photo in product.Photos.Where(photo => photo.Name==photoName))
            foreach (var photo in deletedPhotoNames.PhotosHaveToDelete.SelectMany(photoName => product.Photos.Where(photo => photo.Name==photoName)))
                photo.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        
    }
    
    
}