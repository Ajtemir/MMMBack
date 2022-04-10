using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;

namespace MegaMarketMall.Models.ProductBrands.WashingMachineBrands
{
    public class WashingMachineBrand : IProductBrand<WashingMachine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<WashingMachine> Products { get; set; }
    }
}