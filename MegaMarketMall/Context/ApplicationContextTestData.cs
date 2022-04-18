using System;
using MegaMarketMall.Models.Products.Cluster.Electronics;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.PersonalItems;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories;
using MegaMarketMall.TestData;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);
        // Test
        public DbSet<UserTest> UserTests { get; set; }
        public DbSet<SellerTest> SellerTests { get; set; }
        public DbSet<OwnerTest> OwnerTests { get; set; }
        public DbSet<ProductTest> ProductTests { get; set; }
        
        public DbSet<BrandTest> BrandTests { get; set; }
        public DbSet<WMBrand> WmBrands { get; set; }
        public DbSet<SmBrand> SmBrands { get; set; }
    }
}