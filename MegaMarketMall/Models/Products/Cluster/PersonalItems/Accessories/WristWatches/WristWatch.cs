using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Brands;

namespace MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches
{
    [Table("WristWatch")]
    public class WristWatch : Accessory
    {
        public string Mechanism { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public WristWatchBrand Brand { get; set; }
        public string BrandName => Brand?.Name;
        public string Color { get; set; }
    }
    
    

    
}