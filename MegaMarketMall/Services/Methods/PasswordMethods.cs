using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Dto;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Services.Methods
{
    public static class PasswordMethods
    {
        public static void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
        public  static  async Task<bool> VerifyPasswordHash(AuthUserDto userDto, User user)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userDto.Password));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }
    }
}