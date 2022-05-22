using MegaMarketMall.Models.Tokens;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        public DbSet<User> Users { get; set; }   
        public DbSet<Seller> Sellers { get; set; }   
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        
    }
}