using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Get
{
    public class WashingMachineGet : ProductGet, IWashingMachine, IBrandGet
    {
        public TypeWashingMachine? Type { get; set; }
        public DownloadType? DownloadType { get; set; }
        public Size? Size { get; set; }
        public int? BrandId { get; set; }
    }
}