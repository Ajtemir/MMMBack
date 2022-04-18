using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines
{
    [Table("SewingMachine")]
    public class SewingMachine : Product, ISewingMachine , IBrandFk
    {
        public LoopType? LoopType { get; set; }
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        [JsonIgnore]
        public int? BrandId { get; set; }
        public SewingMachineBrand Brand { get; set; }
    }
}