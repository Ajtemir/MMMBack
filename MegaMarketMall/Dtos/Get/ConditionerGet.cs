using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Get
{
    public class ConditionerGet : ProductGet , IConditionerGet
    {
        public TypeConditioner? Type { get; set; } = null;
        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; } = null;
        public TypeCompressor? TypeCompressor { get; set; } = null;
        public RecommendedAreaSquareMeter? RecommendedArea { get; set; } = null;
        public int? BrandId { get; set; } = null;
    }
}