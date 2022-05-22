using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos.Local.Product;
using MegaMarketMall.Models.ProductPhotos;
using MegaMarketMall.Models.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services
{
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _request;
        

        public ProductPhotoService(ApplicationContext context, IWebHostEnvironment environment, IHttpContextAccessor request)
        {
            _context = context;
            _environment = environment;
            _request = request;
        }

        public async Task CreatePhotosAsync(List<IFormFile> files,int productId)
        {
            if (files is null)
            {
                return;
            }

            List<ProductPhoto> photos = new List<ProductPhoto>(); 
            foreach (var file in files)
            {
                const string directory = "/UploadedProductsPhotos/";
                if (!Directory.Exists(_environment.WebRootPath + directory))
                    Directory.CreateDirectory(_environment.WebRootPath + directory);
                string ext = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                await using var fileStream = System.IO.File.Create(_environment.WebRootPath + directory + fileName);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                string path = _request.HttpContext?.Request.Scheme + "://" + _request.HttpContext?.Request.Host + directory + fileName;
                ProductPhoto photo = new ProductPhoto
                {
                    Name = fileName,
                    UrlPath = path,
                    ProductId = productId,

                };
                photos.Add(photo);
            }
            await _context.AddRangeAsync(photos);
            await _context.SaveChangesAsync();
        }

        public async Task<List<int>> CreatePhotosAsync(List<IFormFile> files)
        {
            List<int> ids = new();
            if (files is null)
            {
                return ids;
            }

            List<ProductPhoto> photos = new List<ProductPhoto>(); 
            foreach (var file in files)
            {
                const string directory = "/UploadedProductsPhotos/";
                if (!Directory.Exists(_environment.WebRootPath + directory))
                    Directory.CreateDirectory(_environment.WebRootPath + directory);
                string ext = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                await using var fileStream = System.IO.File.Create(_environment.WebRootPath + directory + fileName);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                string path = _request.HttpContext?.Request.Scheme + "://" + _request.HttpContext?.Request.Host + directory + fileName;
                ProductPhoto photo = new ProductPhoto()
                {
                    Name = fileName,
                    UrlPath = path,
                };
                photos.Add(photo);
            }
            await _context.AddRangeAsync(photos);
            await _context.SaveChangesAsync();
            ids.AddRange(photos.Select(photo => photo.Id));
            return ids;
        }

        public async Task DeletePhotosAsync(List<string> deletedPhotos, int productId)
        {
            var photos = _context.ProductPhotos.Where(p => p.ProductId == productId).AsQueryable();
            foreach (var photoName in deletedPhotos)
                photos= photos.Where(p => p.ProductId == productId);
            var filtered = await photos.ToListAsync();
            filtered.ForEach(p=>p.ProductId = productId);
            _context.UpdateRange(filtered);
            await _context.SaveChangesAsync();
        }
    }
}