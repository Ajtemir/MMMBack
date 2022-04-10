using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Get
{
    public class ConditionerGet : ProductGet , IConditionerGet
    {
        public string Type { get; set; } = null;
        public string MountingTheIndoorUnit { get; set; } = null;
        public string TypeCompressor { get; set; } = null;
        public string RecommendedArea { get; set; } = null;
        public int? BrandId { get; set; } = null;
    }
}