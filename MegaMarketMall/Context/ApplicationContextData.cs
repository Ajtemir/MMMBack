using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using MegaMarketMall.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MegaMarketMall.Context
{
    public partial class ApplicationContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent api

            modelBuilder.Entity<Category>().HasData(
                // 0 level
                new Category() {Id = CategoryConstants.All, Name = "all", ParentCategoryId = null},

                //1 level
                new Category() {Id = CategoryConstants.Electronics, Name = "Electronics", ParentCategoryId = CategoryConstants.All},
                new Category() {Id = CategoryConstants.PersonalItems, Name = "PersonalItems", ParentCategoryId = CategoryConstants.All},

                // 2 level 
                new Category() {Id = CategoryConstants.HouseHoldAppliances, Name = "HouseHoldAppliances", ParentCategoryId = CategoryConstants.Electronics},
                new Category() {Id = 5, Name = "Accessories", ParentCategoryId = CategoryConstants.PersonalItems},
                new Category() {Id = 6, Name = "MensFootwear", ParentCategoryId = CategoryConstants.PersonalItems},

                // 3 level
                new Category() {Id = 7, Name = "Climatic Equipments", ParentCategoryId = 4},
                new Category()
                    {Id = 8, Name = "OthersHouseHoldAppliance", ParentCategoryId = 4}, // does not have subcategory
                new Category() {Id = 9, Name = "WashingMachine", ParentCategoryId = 4}, // does not have subcategory
                new Category() {Id = 10, Name = "Jewelry", ParentCategoryId = 5},
                new Category() {Id = 11, Name = "WristWatches", ParentCategoryId = 5}, // does not have subcategory
                new Category() {Id = 17, Name = "Boots", ParentCategoryId = 6}, // does not have subcategory
                new Category()
                    {Id = 18, Name = "SneakersAndSportsShoes", ParentCategoryId = 6}, // does not have subcategory
                new Category() {Id = 19, Name = "OtherMensFootwear", ParentCategoryId = 6}, // does not have subcategory

                // 4 level
                new Category() {Id = 12, Name = "Conditioner", ParentCategoryId = 7}, // does not have subcategory
                new Category() {Id = 14, Name = "JewelrySets", ParentCategoryId = 10}, // does not have subcategory
                new Category() {Id = 15, Name = "Earrings", ParentCategoryId = 10}, // does not have subcategory
                new Category() {Id = 16, Name = "Rings", ParentCategoryId = 10} // does not have subcategory
            );
            PasswordMethods.CreatePasswordHashSalt("qwerty-2001", out byte[] passwordHash, out byte[] passwordSalt);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, Email = "User@gmail.com", Firstname = "User", Lastname = "Userov", Role = "User",
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt
                },
                new User
                {
                    Id = 3, Email = "Admin@gmail.com", Firstname = "Admin", Lastname = "Adminov", Role = "Admin",
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt
                },
                new User
                {
                    Id = 4, Email = "Owner@gmail.com", Firstname = "Owner", Lastname = "Ownerov", Role = "Owner",
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt
                }
            );

            modelBuilder.Entity<BazaarSeller>().HasData(
                new BazaarSeller
                {
                    Id = 2,
                    Username = "Seller",
                    Phone = "996706226452",
                    Email = "Seller@gmail.com",
                    Firstname = "Seller",
                    Lastname = "Sellerov",
                    Patronymic = null,
                    IsActive = false,
                    IsDeleted = false,
                    Avatar = null,
                    Role = "Seller",
                    Nickname = null,
                    Description = null,
                    AdAccount = null,
                    Products = null,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new BazaarSeller()
                {
                    Id = 5, Email = "Seller1@gmail.com", Firstname = "Seller1", Lastname = "Sellerov1", Role = "Seller",
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt,Username = "Seller",
                    Phone = "996706226452",
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

            modelBuilder.Entity<WristWatchBrand>().HasData(
                new WristWatchBrand()
                {
                    Id = 3,
                    Name = "Rolex"
                }
            );

            modelBuilder.Entity<SewingMachineBrand>().HasData(
                new SewingMachineBrand()
                {
                    Id = 4,
                    Name = "Toyota"
                }
            );

            modelBuilder.Entity<Conditioner>().HasData(
                new Conditioner
                {
                    Id = 1,
                    SellerId = 2,
                    CategoryId = 12,
                    BrandId = 1
                },
                new Conditioner
                {
                    Id = 2,
                    SellerId = 5,
                    CategoryId = 12,
                    BrandId = 1
                }
            );
            modelBuilder.Entity<WristWatch>().HasData(
                new WristWatch()
                {
                    Id = 3,
                    SellerId = 5,
                    CategoryId = 5,
                    BrandId = 1
                }
            );

            modelBuilder.Entity<SewingMachine>().HasData(
                new SewingMachine()
                {
                    Id = 4,
                    SellerId = 5,
                    CategoryId = 4
                }
            );

            // TODO => think about above
            // TODO => think about email check lowercase
            // Test configuration
            // modelBuilder.Entity<ProductTest>()
            //     .Property(c => c.Type)
            //     .HasConversion(
            //         v => v.ToString(),
            //         v => (ProductTest.Types)Enum.Parse(typeof(ProductTest.Types), v));
        }
    }
}