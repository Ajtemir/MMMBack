using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;

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

        public static void MapBrand<T>(this IBrandFk brand, int? id) where T:Brand
        {
            brand.BrandId = id;
        }
    }
}