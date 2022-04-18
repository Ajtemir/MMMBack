using System;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.ProductPhotos;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Products.Cluster.Electronics;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.OthersHouseHoldAppliances;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.Jewelry;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.MensFootwear;
using MegaMarketMall.Models.Relations;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<MensFootwear> MensFootwears { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Conditioner> Conditioners { get; set; }
        public DbSet<OtherHouseHoldAppliance> OtherHouseHoldAppliances { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        public DbSet<WristWatch> WristWatches { get; set; }
        public DbSet<SewingMachine> SewingMachines { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}