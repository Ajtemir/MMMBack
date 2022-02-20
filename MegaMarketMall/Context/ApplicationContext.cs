using MegaMarketMall.Methods;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.Products;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.OthersHouseHoldAppliances;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.WashingMachines;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.Jewelry;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.MensFootwear;
using MegaMarketMall.Models.Products.ProductBrands.Conditionerbrands;
using MegaMarketMall.Models.Products.ProductBrands.MensFootwearBrands;
using MegaMarketMall.Models.Products.ProductBrands.WashingMachineBrands;
using MegaMarketMall.Models.Products.ProductBrands.WristWatchBrands;
using MegaMarketMall.Models.Relations;
using MegaMarketMall.Models.Users;
using MegaMarketMall.TestData;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<MensFootwear> MensFootwears { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }
        public DbSet<Conditioner> Conditioner { get; set; }
        public DbSet<OtherHouseHoldAppliance> OtherHouseHoldAppliances { get; set; }
        public DbSet<WashingMachine> WashingMachines { get; set; }
        public DbSet<WristWatch> WristWatches { get; set; }
        
        //Brands
        public DbSet<MensFootwearBrand> MensFootwearBrands { get; set; }
        public DbSet<ConditionerBrand> ConditionerBrands { get; set; }
        public DbSet<WashingMachineBrand> WashingMachineBrands { get; set; }
        public DbSet<WristWatchBrand> WristWatchBrands { get; set; }
        
        // Test
        public DbSet<UserTest> UserTests { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options){}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent api
            
            modelBuilder.Entity<Category>().HasData(
                // 0 level
                new Category(){Id = 1, Name = "all",ParentCategoryId = null},
                
                //1 level
                new Category(){Id = 2, Name = "Electronics",ParentCategoryId = 1},
                new Category(){Id = 3, Name = "PersonalItems",ParentCategoryId = 1},
                
                // 2 level 
                new Category(){Id = 4, Name = "HouseHoldAppliances",ParentCategoryId = 2},
                new Category(){Id = 5, Name = "Accessories",ParentCategoryId = 3},
                new Category(){Id = 6, Name = "MensFootwear",ParentCategoryId = 3},
                
                // 3 level
                new Category(){Id = 7, Name = "Climatic Equipments",ParentCategoryId = 4},
                new Category(){Id = 8, Name = "OthersHouseHoldAppliance",ParentCategoryId = 4}, // does not have subcategory
                new Category(){Id = 9, Name = "WashingMachine",ParentCategoryId = 4}, // does not have subcategory
                new Category(){Id = 10, Name = "Jewelry",ParentCategoryId = 5}, 
                new Category(){Id = 11, Name = "WristWatches",ParentCategoryId = 5}, // does not have subcategory
                new Category(){Id = 17, Name = "Boots",ParentCategoryId = 6}, // does not have subcategory
                new Category(){Id = 18, Name = "SneakersAndSportsShoes",ParentCategoryId = 6}, // does not have subcategory
                new Category(){Id = 19, Name = "OtherMensFootwear",ParentCategoryId = 6}, // does not have subcategory

                // 4 level
                new Category(){Id = 12, Name = "Conditioner",ParentCategoryId = 7}, // does not have subcategory
                new Category(){Id = 14, Name = "JewelrySets",ParentCategoryId = 10}, // does not have subcategory
                new Category(){Id = 15, Name = "Earrings",ParentCategoryId = 10}, // does not have subcategory
                new Category(){Id = 16, Name = "Rings",ParentCategoryId = 10} // does not have subcategory
            );
            PasswordMethods.CreatePasswordHashSalt("qwerty-2001",out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User{Id=1,Email = "User@gmail.com",Firstname = "User",Lastname = "Userov", Role="User", PasswordHash = passwordHash, PasswordSalt = passwordSalt},
                new User{Id=2,Email = "Seller@gmail.com",Firstname = "Seller",Lastname = "Sellerov", Role = "Seller", PasswordHash = passwordHash, PasswordSalt = passwordSalt},
                new User{Id=3,Email = "Admin@gmail.com",Firstname = "Admin",Lastname = "Adminov",Role = "Admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt},
                new User{Id=4,Email = "Owner@gmail.com", Firstname = "Owner", Lastname = "Ownerov", Role = "Owner", PasswordHash = passwordHash, PasswordSalt = passwordSalt},
                new User{Id=5,Email = "Seller1@gmail.com",Firstname = "Seller1",Lastname = "Sellerov1", Role = "Seller", PasswordHash = passwordHash, PasswordSalt = passwordSalt}

            );

            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    Id = 1,
                    UserId = 2,
                },
                new Seller
                {
                    Id = 2,
                    UserId = 5,
                }
            );
            
            modelBuilder.Entity<ConditionerBrand>().HasData(
                new ConditionerBrand
                {
                    Id = 1,
                    Name = "LG",
                },
                new ConditionerBrand
                {
                    Id = 2,
                    Name = "Panasonic",
                }
                
            );

            modelBuilder.Entity<Conditioner>().HasData(
                    new Conditioner
                    {
                        Id = 1,
                        SellerId = 1,
                        CategoryId = 12,
                        BrandId = 1
                    },
                    new Conditioner
                    {
                        Id = 2,
                        SellerId = 1,
                        CategoryId = 12,
                        BrandId = 1
                    }
                    
            );

            // TODO => think about above
        }
        
    }
}