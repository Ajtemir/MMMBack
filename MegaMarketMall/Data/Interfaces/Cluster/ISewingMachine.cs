using MegaMarketMall.Data.Enums.SewingMachine;

namespace MegaMarketMall.Data.Interfaces.Cluster
{
    public interface ISewingMachine
    {
        public LoopType? LoopType { get; set; }
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        
    }
}