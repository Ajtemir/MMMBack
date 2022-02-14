using System.Collections.Generic;

namespace MegaMarketMall.Models.Products.ProductBrands
{
    public class ProductBrand<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<T> Products { get; set; }
    }
}