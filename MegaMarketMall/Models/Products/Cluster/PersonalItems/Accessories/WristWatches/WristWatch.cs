using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;

namespace MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches
{
    [Table("WristWatch")]
    public class WristWatch : Product,IBrandFk,IWristWatch
    {
        public string Mechanism { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }

        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual WristWatchBrand Brand { get; set; }
    }
}