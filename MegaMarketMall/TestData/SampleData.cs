using System.Linq;
using System.Security.Cryptography;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.TestData
{
    public static class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                CreatePasswordHashTest("Qwerty-2001",out byte[] passwordHash,out byte[] passwordSalt);
                context.Users.AddRange(
                    new User
                    {
                        Email = "User@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    },
                    new User
                    {
                        Email = "Admin@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "Admin"
                    },
                    new User
                    {
                        Email = "Owner@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "Owner"
                    },
                    new User
                    {
                        Email = "Seller@gmail.com",
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Role = "Seller"
                    }
                );
                context.SaveChanges();
            }
        }
        
        private static void CreatePasswordHashTest(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
    
    
}