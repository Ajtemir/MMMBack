using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Brand;

namespace MegaMarketMall.Models.ProductBrands
{
    public class ProductBrand<T>:IProductBrand<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<T> Products { get; set; }
    }
}