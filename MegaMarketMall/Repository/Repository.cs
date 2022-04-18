using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Services.CategoryService;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Repository
{
    
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class,IEntity
    {
        private readonly ApplicationContext _context;
        private IQueryable<TEntity> _products;
        private ICategoryService _category;

        public Repository(ApplicationContext context, ICategoryService category)
        {
            _context = context;
            _category = category;
            _products = _context.Set<TEntity>().AsQueryable();
        }


        public IQueryable<TEntity> Filter(ProductGet query)
        {
            // var products = _context.Set<TEntity>().AsQueryable();
            if (query.FromPrice is not null)
                _products = _products.Where(p => p.Price >= query.FromPrice);
            if (query.ToPrice is not null)
                _products = _products.Where(p => p.Price <= query.ToPrice);
            if (!string.IsNullOrEmpty(query.Text))
                _products = _products.Where(p => p.Description.Contains(query.Text));
            if (query.Deliver is null)
                _products = _products.Where(p => p.IsDelivered == null);
            else if (query.Deliver.Value)
                _products = _products.Where(p => p.IsDelivered == true);
            else 
                _products = _products.Where(p => p.IsDelivered == false);
            
            _products = query.SortBy switch
            {
                "newest" => _products
                    .OrderByDescending(p => p.TimeStamp),
                "ascending" => _products.OrderBy(p => p.Price),
                "descending" => _products.OrderByDescending(p => p.Price),
                _ => _products.OrderBy(p=>p.TimeStamp)
            };
            return _products;
        }

        

        public async Task<QueryResponse<TEntity>> PaginateAsync(IQueryable<TEntity> products, IPage pages)
        {
            var page = pages.Page;
            page ??= 1;
            page = page > 0 ? page : 1;
            float pageResult = PaginationConstant.CountElementsInPage;
            var pageCount = Math.Ceiling(await products.CountAsync() / pageResult);
            var result = await products
                .Include(p=>p.Photos.Where(o=>o.IsDeleted==false))
                .Skip(((page.Value - 1) * (int)pageResult))
                .Take((int)pageResult)
                .ToListAsync(); 
            
            return new QueryResponse<TEntity>()
            {
                Products = result,
                CurrentPage = page.Value,
                Pages = (int)pageCount
            };
        }

        public IQueryable<TEntity> Paginate(IQueryable<TEntity> products, int page)
        {
            float pageResult = PaginationConstant.CountElementsInPage;
            var result = products
                .Include(p => p.Photos.Where(o => o.IsDeleted == false))
                .Skip(((page - 1) * (int) pageResult))
                .Take((int) pageResult).AsQueryable();
            return result;
        }

        public async Task<QueryResponse<TEntity>> ToListAsync(IQueryable<TEntity> products,IPage pages)
        {
            var page = pages.Page;
            page ??= 1;
            page = page > 0 ? page : 1;
            float pageResult = PaginationConstant.CountElementsInPage;
            var pageCount = Math.Ceiling(await products.CountAsync() / pageResult);
            var paginated = Paginate(products, page.Value);
            var result = await paginated.ToListAsync();
            return new QueryResponse<TEntity>()
            {
                Products = result,
                CurrentPage = page.Value,
                Pages = (int)pageCount
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