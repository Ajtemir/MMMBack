using MegaMarketMall.Models.Brands;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ConditionerBrand> ConditionerBrands { get; set; }
        public DbSet<WashingMachineBrand> WashingMachineBrands { get; set; }
        public DbSet<SewingMachineBrand> SewingMachineBrands { get; set; }
    }
}