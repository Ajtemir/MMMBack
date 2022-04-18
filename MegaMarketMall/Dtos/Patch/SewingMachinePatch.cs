using System.Collections.Generic;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Post;
using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos.Patch
{
    public class SewingMachinePatch : IProductCore, ISewingMachine,IBrandFk
    {
        public int? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
        public LoopType? LoopType { get; set; }
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        public int? BrandId { get; set; }
    }
}