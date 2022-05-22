using System;
using System.IO;
using System.Threading.Tasks;
using MegaMarketMall.Data.Interfaces.Avatar;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Services.AvatarService
{
    public class AvatarService : IAvatarService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _request;


        public AvatarService(IWebHostEnvironment environment, IHttpContextAccessor request)
        {
            _environment = environment;
            _request = request;
        }

        public async Task<string> CreateAvatarAsync(IAvatar avatar)
        {
            var file = avatar.Avatar;
            if (file == null)
                return null;
            const string directory = "/UploadedAvatar/";
            if (!Directory.Exists(_environment.WebRootPath + directory))
                Directory.CreateDirectory(_environment.WebRootPath + directory);
            string ext = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString().Replace("-", "") + ext;
            await using var fileStream = System.IO.File.Create(_environment.WebRootPath + directory + fileName);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            string path = _request.HttpContext?.Request.Scheme + "://" + _request.HttpContext?.Request.Host + directory + fileName;
            return path;
        }
    }
}