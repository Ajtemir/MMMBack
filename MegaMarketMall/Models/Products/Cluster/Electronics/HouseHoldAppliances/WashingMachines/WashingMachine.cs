using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products.ProductBrands.WashingMachineBrands;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines
{
    [Table("WashingMachine")]
    public class WashingMachine : Product
    {
        public int? BrandId { get; set; } = null;
        [ForeignKey("BrandId")]
        public WashingMachineBrand Brand { get; set; }
        public string BrandName => Brand.Name;  //TODO => think about brand name
        public string TypeDownload { get; set; }
        public int MaxDownload { get; set; }
        public string TypeOfMachine { get; set; }
        public string SizeMachine { get; set; }
        
        
        
        
    }
}