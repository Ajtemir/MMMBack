using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products.ProductBrands.Conditionerbrands;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments
{
    [Table("Conditioner")]
    public class Conditioner : Product
    {
        public int? BrandId { get; set; }
        
        [ForeignKey("BrandId")]
        public ConditionerBrand Brand { get; set; }
        public string BrandName => Brand.Name;
        public string Type { get; set; } = null;
        public string MountingTheIndoorUnit { get; set; } = null;
        public string TypeCompressor { get; set; } = null;

    }

    
}