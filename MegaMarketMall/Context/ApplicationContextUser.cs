using MegaMarketMall.Models.Tokens;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        public DbSet<User> Users { get; set; }   
        public DbSet<Seller> Sellers { get; set; }   
        public DbSet<OnlineSeller> OnlineSellers { get; set; }   
        public DbSet<ShopSeller> ShopSellers { get; set; }   
        public DbSet<BazaarSeller> BazaarSellers { get; set; }   
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        
    }
}