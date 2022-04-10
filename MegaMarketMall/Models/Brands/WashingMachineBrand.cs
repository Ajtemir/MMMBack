using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;

namespace MegaMarketMall.Models.Brands
{
    public class WashingMachineBrand : Brand
    {
        public List<WashingMachine> Products { get; set; }
    }
}