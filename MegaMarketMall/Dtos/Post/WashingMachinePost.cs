using System.Collections.Generic;
using MegaMarketMall.Data.Attributes;
using MegaMarketMall.Data.Enums.WashingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Post;
using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos.Post
{
    public class WashingMachinePost : IProductCore, IWashingMachine, IProductPhotos, ICategoryId
    {
        public int? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
        public Type? Type { get; set; }
        [RequiredEnum(ErrorMessage = "Error no such option")]
        public DownloadType? DownloadType { get; set; }
        public Size? Size { get; set; }
        public List<IFormFile> Files { get; set; }
        public int CategoryId { get; set; }
    }

}