using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products.ProductBrands.MensFootwearBrands;

namespace MegaMarketMall.Models.Products.Cluster.PersonalItems.MensFootwear
{
    [Table("MensFootwear")]
    public class MensFootwear : Product
    {
        [Column("Size", TypeName = "integer[]")]
        public int[] Size { get; set; }
        public string Color { get; set; } = null;
        public string Condition { get; set; } = null;
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public MensFootwearBrand Brand { get; set; } = null;
        public string BrandName => Brand.Name = Brand.Name;
    }
}