using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos.Local.Product
{
    public class PatchPhoto
    {
        public List<IFormFile> AddedPhotos { get; set; }
        public List<string> RemovedPhotos { get; set; }
    }
}