using System.Collections.Generic;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Put
{
    public class ConditionerPut : BaseProductPut, IConditioner, IBrandGet, IPhotoDelete
    {
        
        public int? BrandId { get; set; }
        public List<string> PhotosHaveToDelete { get; set; }
        public TypeConditioner? Type { get; set; }
        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; }
        public TypeCompressor? TypeCompressor { get; set; }
        public RecommendedAreaSquareMeter? RecommendedArea { get; set; }
    }
}