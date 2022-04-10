using MegaMarketMall.Data.Enums.WashingMachine;

namespace MegaMarketMall.Data.Interfaces.Cluster
{
    public interface IWashingMachine
    {
        public Type? Type { get; set; }
        public DownloadType? DownloadType { get; set; }
        public Size? Size { get; set; }
    }
}