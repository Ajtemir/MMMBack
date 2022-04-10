using System;
using System.Collections.Generic;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Post;
using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MegaMarketMall.Dtos.Post
{
    public class ConditionerPost : IProductCore , IConditioner, IProductPhotos, ICategoryId
    {
        public string Type { get; set; }
        public string MountingTheIndoorUnit { get; set; }
        public string TypeCompressor { get; set; }
        public string RecommendedArea { get; set; }
        public uint? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
        public int CategoryId { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}