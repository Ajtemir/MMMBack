using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Dtos;
using MegaMarketMall.Dtos.Get;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace MegaMarketMall.Services
{
    public interface IProductService
    { 
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
        IQueryable<Product> Filter(ProductGet query);
        Task<ProductResponse> Paginate(IQueryable<Product> products, int? page);

        void MapProduct(Product product, BaseProductPut putData);



    }
}