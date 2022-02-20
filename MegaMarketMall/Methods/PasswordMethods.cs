using System.Linq;
using System.Security.Cryptography;
using MegaMarketMall.Models.Dto;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Methods
{
    public static class PasswordMethods
    {
        public static void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(AuthRequest request, User user)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(request.Password));
            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}