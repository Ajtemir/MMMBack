using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos.Local.Product
{
    public class PostPhoto
    {
        public List<IFormFile> AddedPhotos { get; set; }

    }
}