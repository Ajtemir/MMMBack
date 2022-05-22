using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;

namespace MegaMarketMall.Models.Brands
{
    public class WristWatchBrand : Brand
    {
        public virtual List<WristWatch> Products { get; set; }
    }
}