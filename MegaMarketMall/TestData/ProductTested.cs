using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MegaMarketMall.TestData
{
    public class ProductTested
    {
        public int  Id { get; set; }
        public int Price { get; set; }
        public virtual int ExtraId { get; set; }
    }

    public class Kettle : ProductTested
    {
        public override int ExtraId { get; set; }
        [ForeignKey("ExtraId")]
        public KettleExtra Extra { get; set; }
    }

    public class KettleExtra
    {
        public int Voltage { get; set; } = 240;
        [JsonIgnore] public int BrandId { get; set; } = 24;

        public String BrandName { get; set; } = "sdgdf";
    }
}