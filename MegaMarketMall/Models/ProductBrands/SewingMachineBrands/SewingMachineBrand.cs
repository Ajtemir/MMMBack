using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;

namespace MegaMarketMall.Models.ProductBrands.SewingMachineBrands
{
    public class SewingMachineBrand : IProductBrand<SewingMachine>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SewingMachine> Products { get; set; } = new();
    }
}