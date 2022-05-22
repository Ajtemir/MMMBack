using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner
{
    [Table("Conditioner")]
    public class Conditioner : Product, IConditioner, IBrandFk
    {
        [JsonIgnore]

        public TypeConditioner? Type { get; set; } = null;
        [JsonIgnore]

        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; } = null;
        [JsonIgnore]

        public TypeCompressor? TypeCompressor { get; set; } = null;
        [JsonIgnore]

        public RecommendedAreaSquareMeter? RecommendedArea { get; set; } = null;
        [JsonIgnore]
        public int? BrandId { get; set; } = null;
        
        [JsonIgnore, ForeignKey("BrandId")]
        public virtual ConditionerBrand Brand { get; set; }

        [JsonProperty("Extra")]

        public ExtraConditioner ExtraConditioner => new()
        {
            Type = Type,
            MountingTheIndoorUnit = MountingTheIndoorUnit,
            TypeCompressor = TypeCompressor,
            RecommendedArea = RecommendedArea,
            Brand = Brand?.Name
        };



    }

    public class ExtraConditioner
    {
        [JsonProperty("Тип кондиционера")]

        public TypeConditioner? Type { get; set; } = null;
        [JsonProperty("Монтаж внутреннего блока")]

        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; } = null;
        [JsonProperty("Тип компрессора")]
        
        public TypeCompressor? TypeCompressor { get; set; } = null;
        [JsonProperty("Рекомендованная площадь (м2)")]

        public RecommendedAreaSquareMeter? RecommendedArea { get; set; } = null;
        [JsonProperty("Бренд")]
        public string Brand { get; set; } = null;
    }

    
}