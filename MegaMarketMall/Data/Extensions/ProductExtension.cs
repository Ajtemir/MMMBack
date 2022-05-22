using System.Linq;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Dtos.Response.ProductView;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Data.Extensions
{
    public static class ProductExtension 
    {
        public static void MapProductPutData(this IProductCore product, BaseProductPut putData)
        {
            product.Description = putData.Description;
            product.Price = putData.Price;
            product.IsDelivered = putData.IsDelivered;
        }
        
        public static ProductView MapToProductView(this Product product)
        {
            return new ProductView
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
                }
            };
        }

        
    }
}