using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;

namespace MegaMarketMall.TestData
{
    public class BrandTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class SmBrand : BrandTest
    {
        public virtual List<SewingMachine> SewingMachines { get; set; }
    }

    public class WMBrand : BrandTest
    {
        public virtual List<WashingMachine> WashingMachines { get; set; }
    }
}