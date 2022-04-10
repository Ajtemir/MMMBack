using System.Collections.Generic;
using MegaMarketMall.Data.Abstracts;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Delete;
using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Dtos.Put
{
    public class ConditionerPut : BaseProductPut, IConditioner, IBrandGet, IPhotoDelete
    {
        
        public int? BrandId { get; set; }
        public List<string> PhotosHaveToDelete { get; set; }
        public string Type { get; set; }
        public string MountingTheIndoorUnit { get; set; }
        public string TypeCompressor { get; set; }
        public string RecommendedArea { get; set; }
    }
}