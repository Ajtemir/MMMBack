using System;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationContext _context;

        public ProductService(ApplicationContext context)
        {
            _context = context;
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

        public async Task<ProductResponse> Paginate(IQueryable<Product> products, int? page)
        {
            page ??= 1;
            page = page > 0 ? page : 1;
            const float pageResult = 1F;
            var pageCount = Math.Ceiling(_context.Products.Count() / pageResult);
            var result = await _context.Products
                .Skip(((page.Value - 1) * (int)pageResult))
                .Take((int)pageResult)
                .ToListAsync();
            return new ProductResponse
            {
                Products = result,
                CurrentPage = page.Value,
                Pages = (int)pageCount
            };
        }

        public void MapProduct(Product product, BaseProductPut putData)
        {
            product.Description = putData.Description;
            product.Price = putData.Price;
            product.IsDelivered = putData.IsDelivered;
        }
    }
}