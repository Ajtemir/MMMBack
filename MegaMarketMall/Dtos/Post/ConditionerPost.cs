using System;
using System.Collections.Generic;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Post;
using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MegaMarketMall.Dtos.Post
{
    public class ConditionerPost : IProductCore , IConditioner, IProductPhotos, ICategoryId
    {
        public Data.Enums.Conditioner.TypeConditioner? Type { get; set; }
        public MountingTheIndoorUnit? MountingTheIndoorUnit { get; set; }
        public TypeCompressor? TypeCompressor { get; set; }
        public RecommendedAreaSquareMeter? RecommendedArea { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}