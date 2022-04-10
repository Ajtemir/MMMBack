using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Get.Cluster
{
    public class SewingMachineGet : ProductGet, ISewingMachine, IBrandGet
    {
        public LoopType? LoopType { get; set; }
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        public int? BrandId { get; set; }
    }
}