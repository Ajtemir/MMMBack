using System.Collections.Generic;
using System.Threading.Tasks;
using MegaMarketMall.Dtos.Local.Product;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Services
{
    public interface IProductPhotoService
    {
        Task CreatePhotosAsync(List<IFormFile> photos,int productId);
        Task<List<int>> CreatePhotosAsync(List<IFormFile> photos);
        Task DeletePhotosAsync(List<string> deletedPhotos, int productId);


    }
}