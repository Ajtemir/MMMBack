using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response;
using MegaMarketMall.Dtos.Response.ProductView;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Repository;
using MegaMarketMall.Services.CategoryService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MegaMarketMall.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;
        private readonly ICategoryService _category;
        private readonly IRepository<Product> _repository;

        public ProductService(ApplicationContext context, ICategoryService category, IRepository<Product> repository)
        {
            _context = context;
            _category = category;
            _repository = repository;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p=>p.Seller)
                .FirstOrDefaultAsync(p=>p.Id==id);
            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Product> Filter(ProductGet query)
        {
            IQueryable<Product> products = _context.Products.AsQueryable();
            products = Filter(products, query);
            return products;
        }

        public IQueryable<Product> Filter(IQueryable<Product> products, ProductGet query)
        {
            if (query.FromPrice is not null)
                products = products.Where(p => p.Price >= query.FromPrice);
            if (query.ToPrice is not null)
                products = products.Where(p => p.Price <= query.ToPrice);
            if (!string.IsNullOrEmpty(query.Text))
                products = products.Where(p => p.Description.Contains(query.Text));
            // Deliver
            if (query.Deliver is null)
                products = products.Where(p => p.IsDelivered == null);
            else if (query.Deliver.Value)
                products = products.Where(p => p.IsDelivered == true);
            else 
                products = products.Where(p => p.IsDelivered == false);
            
            products = query.SortBy switch
            {
                "newest" => products
                    .OrderByDescending(p => p.TimeStamp.Date)
                    .ThenBy(p => p.TimeStamp.TimeOfDay),
                "ascending" => products.OrderBy(p => p.Price),
                "descending" => products.OrderByDescending(p => p.Price),
                _ => products
            };
            return products;
        }

        public async Task<IQueryable<Product>> FilterByParentCategoryIdAndQueriesAsync(ProductGet query, int parentCategoryId)
        {
            IQueryable<Product> products = _context.Products.AsQueryable();
            products = await FilterByParentCategoryIdAsync(products, parentCategoryId);
            products = Filter(products, query);
            return products;
        }

        public async Task<IQueryable<Product>> FilterByParentCategoryIdAsync(IQueryable<Product> products, int parentCategoryId)
        {
            var categories = await _category.GetLowestSubCategoriesIdAsync(parentCategoryId);
            if(!categories.IsNullOrEmpty())
                products = products.Where(p => categories.Contains(p.CategoryId));
            return products;
        }


        public async Task<QueryResponse<Product>> PaginateAsync(IQueryable<Product> products, IPage pages)
        {
            var included = Include(products);
            var result =await _repository.PaginateAsync(included, pages);
            return result;
        }

        public async Task<ProductViewResponse> PaginateProductViewsAsync(IQueryable<Product> products, IPage pages)
        {
            int page = PageToIPage.GetPage(pages);
            var paginated = _repository.Paginate(products, page);
            var pageCount = Math.Ceiling(await products.CountAsync() / PaginationConstant.CountElementsInPage);
            return new ProductViewResponse
            {
                Products = await ToListProductViewsAsync(products),
                Pages = (int)pageCount,
                CurrentPage = page
            };

        }

        public async Task<List<ProductView>> ToListProductViewsAsync(IQueryable<Product> products)
        {
            var result = await products.Select(product => new ProductView
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price,
                Views = product.Views,
                Favorites = product.Favorites,
                Photos = product.Photos.Select(photo => photo.Path).ToList(),
                Category = new CategoryView
                {
                    Id = product.CategoryId,
                    Name = product.CategoryName
                },
                Seller = new SellerView
                {
                    Username = product.Seller.Username,
                    Phone = product.SellerPhone,
                    Avatar = product.Seller.Avatar
                }
            }).ToListAsync();
            return result;
        }

        private IQueryable<Product> Include(IQueryable<Product> products)
        {
            var result = products.Include(product => product.Category).Include(product => product.Seller).AsQueryable();
            return result;
            
        }
        
        private IQueryable<Product> Select(IQueryable<Product> products)
        {
            var result = products.Include(product => products.Select(obj => new
            {
                Created = obj.TimeStampDay,
                
                Seller = new {
                    Username = obj.Seller.Username,
                    Phone = obj.Seller.Phone,
                    Avatar = obj.Seller.Avatar
                }
            })).AsQueryable();
            return result;
            
        }
        
        

        public void MapProduct(Product product, BaseProductPut putData)
        {
            product.Description = putData.Description;
            product.Price = putData.Price;
            product.IsDelivered = putData.IsDelivered;
        }
    }
}