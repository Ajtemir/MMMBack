using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Brands
{
    public class SewingMachineBrand : Brand
    {
        [JsonIgnore]
        public virtual List<SewingMachine> Products { get; set; }
    }
}