using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines
{
    [Table("WashingMachine")]
    public class WashingMachine : Product, IWashingMachine, IBrandFk
    {
        public int? BrandId { get; set; } = null;
        [ForeignKey("BrandId")]
        public WashingMachineBrand Brand { get; set; }
        public string BrandName => Brand.Name;  //TODO => think about brand name


        public Type? Type { get; set; } 
        public DownloadType? DownloadType { get; set; }
        public Size? Size { get; set; }
    }
}