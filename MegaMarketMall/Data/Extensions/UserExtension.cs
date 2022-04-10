using System.Linq;
using System.Security.Cryptography;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Data.Extensions
{
    public static class UserExtension 
    {
        public static bool CheckPassword(this User user, string password)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(user.PasswordHash);
        }
    }
}