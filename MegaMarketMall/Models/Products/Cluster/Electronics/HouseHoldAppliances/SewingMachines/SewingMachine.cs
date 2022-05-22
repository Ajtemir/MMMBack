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
        [JsonIgnore]
        public LoopType? LoopType { get; set; }
        [JsonIgnore]
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        [JsonIgnore]
        public int? BrandId { get; set; }
        [JsonIgnore]
        public virtual SewingMachineBrand Brand { get; set; }

        [JsonProperty("Extra")]

        public ExtraSewingMachine ExtraSewingMachine => new()
        {

            LoopType = LoopType,
            TypeOfSewingMachine = TypeOfSewingMachine,
            Name = Brand?.Name
        };

    }

    public class ExtraSewingMachine 
    {
        [JsonProperty("Тип петли")]

        public LoopType? LoopType { get; set; }
        [JsonProperty("Тип машинки")]

        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        [JsonProperty("Бренд")]

        public string Name { get; set; }
    }
}