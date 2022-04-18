using System.Collections.Generic;
using MegaMarketMall.Data.Attributes;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Interfaces.Cluster;
using MegaMarketMall.Data.Interfaces.Post;
using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos.Post
{
    public class SewingMachinePost:IProductCore, ISewingMachine, IProductPhotos, ICategoryId, IProductBrandPost
    {
        public int? Price { get; set; }
        public string Description { get; set; }
        public bool? IsDelivered { get; set; }
        [RequiredEnum(ErrorMessage = "Error no such option")]
        public LoopType? LoopType { get; set; }
        [RequiredEnum(ErrorMessage = "Error no such option")]
        public TypeOfSewingMachine? TypeOfSewingMachine { get; set; }
        public List<IFormFile> Files { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}