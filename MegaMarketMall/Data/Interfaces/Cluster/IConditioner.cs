using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Enums.WashingMachine;

namespace MegaMarketMall.Data.Interfaces.Cluster
{
    public interface IConditioner 
    {
        public TypeConditioner? Type { get; set; } 
        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; } 
        public TypeCompressor? TypeCompressor { get; set; }
        public RecommendedAreaSquareMeter? RecommendedArea { get; set; }
        

    }
}