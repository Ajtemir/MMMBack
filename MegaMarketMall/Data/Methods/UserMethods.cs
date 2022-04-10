using System;
using System.IO;
using System.Threading.Tasks;
using MegaMarketMall.Dtos;
using MegaMarketMall.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Data.Methods
{
    public static class UserMethods
    {
        public static User CreateUser(RegisterUserDto userDto)
        {
            PasswordMethods.CreatePasswordHashSalt(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Phone = userDto.Phone,
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Patronymic = userDto.Patronymic,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Avatar = userDto.AvatarPath
            };
        }

        public static async Task<string> CreateFilePath(IFormFile file,IWebHostEnvironment environment, HttpRequest request)
        {
                const string directory = "/UploadedUsersAvatar/";
                if (!Directory.Exists(environment.WebRootPath + directory))
                    Directory.CreateDirectory(environment.WebRootPath + directory);
                string ext = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString().Replace("-", "") + ext;
                await using var fileStream = System.IO.File.Create(environment.WebRootPath + directory + fileName);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                string path = request.Scheme + "://" + request.Host + directory + fileName;
                return path;
        }
    }
}