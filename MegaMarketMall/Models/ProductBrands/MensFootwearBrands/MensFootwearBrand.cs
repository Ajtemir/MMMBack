using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.MensFootwear;

namespace MegaMarketMall.Models.ProductBrands.MensFootwearBrands
{
    public class MensFootwearBrand : IProductBrand<MensFootwear>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MensFootwear> Products { get; set; }
    }
}