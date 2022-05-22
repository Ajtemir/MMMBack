using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Brands;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines
{
    [Table("WashingMachine")]
    public class WashingMachine : Product, IWashingMachine, IBrandFk
    {
        [JsonIgnore]
        public int? BrandId { get; set; } = null;
        [ForeignKey("BrandId")]
        [JsonIgnore]

        public virtual WashingMachineBrand Brand { get; set; }
        [JsonIgnore]

        public TypeWashingMachine? Type { get; set; } 
        [JsonIgnore]

        public DownloadType? DownloadType { get; set; }
        [JsonIgnore]

        public Size? Size { get; set; }

        [JsonProperty("Extra")]
        public ExtraWashingMachine ExtraWashingMachine => new()
        {
            Type = Type,
            DownloadType = DownloadType,
            Size = Size,
            Brand = Brand?.Name
        };
    }

    public class ExtraWashingMachine
    {
        [JsonProperty("Тип")]
        public TypeWashingMachine? Type { get; set; } 
        [JsonProperty("Тип загрузки")]
        public DownloadType? DownloadType { get; set; }
        [JsonProperty("Размер")]
        public Size? Size { get; set; } 
        [JsonProperty("Бренд")]
        public string Brand { get; set; }
    }
    
}