using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner
{
    [Table("Conditioner")]
    public class Conditioner : ClimaticEquipment, IConditioner, IBrandFk
    {
        public string Type { get; set; } = null;
        public string MountingTheIndoorUnit { get; set; } = null;
        public string TypeCompressor { get; set; } = null;
        public string RecommendedArea { get; set; } = null;
        public int? BrandId { get; set; } = null;


        [JsonIgnore, ForeignKey("BrandId")]
        public ConditionerBrand Brand { get; set; }
    }

    
}