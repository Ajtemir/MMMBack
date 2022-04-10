using MegaMarketMall.Data.Interfaces.Cluster;

namespace MegaMarketMall.Data.Extensions.Cluster
{
    public static class ConditionerExtension
    {
        public static void MapAdditionalPutData(this IConditioner conditioner, IConditioner data)
        {
            conditioner.Type = data.Type;
            conditioner.RecommendedArea = data.RecommendedArea;
            conditioner.TypeCompressor = data.TypeCompressor;
            conditioner.MountingTheIndoorUnit = data.MountingTheIndoorUnit;
        }
    }
}