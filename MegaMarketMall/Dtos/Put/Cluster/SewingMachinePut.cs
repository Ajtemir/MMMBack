using System.Collections.Generic;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Attributes;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Put.Cluster
{
    public class SewingMachinePut : BaseProductPut, ISewingMachine, IProductBrandPut
    {
        [ValidEnumValue]
        public LoopType? LoopType { get; set; }
        [ValidEnumValue]
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        public int BrandId { get; set; }
    }
}