using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Data.Interfaces.Post
{
    public interface IProductPhotos
    {
        public List<IFormFile> Files { get; set; }
    }
}