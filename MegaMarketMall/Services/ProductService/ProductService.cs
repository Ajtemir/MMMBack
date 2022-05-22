using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Extensions;
using MegaMarketMall.Data.Extensions.Cluster;
using MegaMarketMall.Data.Interfaces.Get;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Dtos.Response;
using MegaMarketMall.Dtos.Response.ProductView;
using MegaMarketMall.Dtos.Response.QueryResponse;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Repositories;
using MegaMarketMall.Services.CategoryService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MegaMarketMall.Services.ProductService
{
    public partial class ProductService : IProductService
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
            products = products.Where(p => p.IsDelivered == query.Deliver);
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
            IQueryable<Product> products = GetProducts();
            products = await FilterByParentCategoryIdAsync(products, parentCategoryId);
            products = Filter(products, query);
            products = Include(products);
            return products;
        }

        public async Task<IQueryable<Product>> FilterByParentCategoryIdAsync(IQueryable<Product> products, int parentCategoryId)
        {
            var categories = await _category.GetLowestSubCategoriesIdAsync(parentCategoryId);
            if(!categories.IsNullOrEmpty())
                products = products.Where(p => categories.Contains(p.CategoryId));
            return products;
        }


        public async Task<QueryResponse<Product>> PaginateAsync(IQueryable<Product> products, IPage page)
        {
            var included = Include(products);
            var result =await _repository.PaginateAsync(included, page);
            return result;
        }

        public async Task<ProductViewResponse> PaginateProductViewsAsync(IQueryable<Product> products, IPage page)
        {
            int currentPage = page.GetPage();
            var paginated = _repository.Paginate(products, page);
            var pageCount = Math.Ceiling(await products.CountAsync() / PaginationConstant.CountProductsInPage);
            return new ProductViewResponse
            {
                Products = await Select(paginated).ToListAsync(),
                Pages = (int)pageCount,
                CurrentPage = currentPage
            };

        }

        public async Task<ProductViewResponse> PaginateProductViewsAsync(IQueryable<ProductView> products, IPage page)
        {
            int currentPage = page.GetPage();
            var paginated = Paginate(products, page);
            var pageCount = Math.Ceiling(await products.CountAsync() / PaginationConstant.CountProductsInPage);
            return new ProductViewResponse
            {
                Products = await paginated.ToListAsync(),
                Pages = (int)pageCount,
                CurrentPage = currentPage
            };
        }

        public IQueryable<ProductView> Select(IQueryable<Product> products)
        {
            var result = products.Select(product => new ProductView
            {
                Id = product.Id,
                Description = product.Description,
                Price = product.Price,
                Views = product.Views,
                Favorites = product.Favorites,
                Photos = product.Photos.Select(photo => photo.UrlPath).ToList(),
                Category = new CategoryView
                {
                    Id = product.CategoryId,
                    Name = product.Category.Name
                },
                Seller = new SellerView
                {
                    Username = product.Seller.Username,
                    Phone = product.Seller.Phone,
                    Avatar = product.Seller.Avatar
                },
                TimeStamp = product.TimeStampDay,
                Updated = product.TimeStampDay,
                Deliver = product.GetDeliverString()
            }).AsQueryable();
            return result;
        }
        

        public IQueryable<Product> Include(IQueryable<Product> products)
        {
            var result = products
                .Include(product => product.Category)
                .Include(product => product.Seller)
                .AsQueryable();
            return result;
            
        }
        public IQueryable<Product> IncludeWithPhoto(IQueryable<Product> products)
        {
            var result = products
                .Include(product => product.Category)
                .Include(product => product.Seller)
                .Include(p => p.Photos.Where(o => o.IsDeleted == false))
                .AsQueryable();
            return result;
            
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products.AsQueryable();
        }

        public IQueryable<ProductView> Paginate(IQueryable<ProductView> products, IPage page)
        {
            var currentPage = page.GetPage();
            float countInPage = PaginationConstant.CountProductsInPage;
            var result = products
                .Skip(((currentPage - 1) * (int) countInPage))
                .Take((int) countInPage).AsQueryable();
            return result;
        }

        // public List<ProductView> Test()
        // {
        //     var products = GetProducts();
        //     var included = Include(products);
        //     var selected = included.Select(product => product.MapToProductView()).AsQueryable();
        //     return selected.ToList();
        // }


        // public void MapProduct(Product product, BaseProductPut putData)
        // {
        //     product.Description = putData.Description;
        //     product.Price = putData.Price;
        //     product.IsDelivered = putData.IsDelivered;
        // }
    }
}