using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;

namespace MegaMarketMall.Models.ProductBrands.WristWatchBrands
{
    public class WristWatchBrand : IProductBrand<WristWatch>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WristWatch> Products { get; set; }
    }
}