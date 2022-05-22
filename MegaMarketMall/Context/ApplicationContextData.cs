using System;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Enums.SewingMachine;
using MegaMarketMall.Data.Methods;
using MegaMarketMall.Models.Brands;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.ProductPhotos;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.SewingMachines;
using MegaMarketMall.Models.Products.Cluster.PersonalItems.Accessories.WristWatches;
using MegaMarketMall.Models.Users;
using MegaMarketMall.TestData;
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
                new Category{Id = CategoryConstants.All, Name = "all", ParentCategoryId = null,RussianName = "Все"},

                //1 level
                new Category{
                    Id = CategoryConstants.Electronics,
                    Name = "Electronics",
                    ParentCategoryId = CategoryConstants.All,
                    RussianName = "Электроника"
                },
                new Category() {Id = CategoryConstants.PersonalItems, Name = "PersonalItems", ParentCategoryId = CategoryConstants.All,RussianName = "Личные вещи"},

                // 2 level 
                new Category() {Id = CategoryConstants.HouseHoldAppliances, Name = "HouseHoldAppliances", ParentCategoryId = CategoryConstants.Electronics},
                new Category() {Id = 5, Name = "Accessories", ParentCategoryId = CategoryConstants.PersonalItems},
                new Category() {Id = 6, Name = "MensFootwear", ParentCategoryId = CategoryConstants.PersonalItems},

                // 3 level
                new Category() {Id = CategoryConstants.ClimaticEquipments, Name = "Climatic Equipments", ParentCategoryId = CategoryConstants.HouseHoldAppliances},
                new Category()
                {
                    Id = 8, Name = "OthersHouseHoldAppliance", ParentCategoryId = CategoryConstants.HouseHoldAppliances,RussianName = 
                        ""
                }, // does not have subcategory
                new Category() {Id = 9, Name = "WashingMachine", ParentCategoryId = CategoryConstants.HouseHoldAppliances}, // does not have subcategory
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
                    Id = 1, Email = "User@gmail.com", Firstname = "User", Lastname = "Userov", Role = UserRoles.User,
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt
                },
                
                new User
                {
                    Id = 4, Email = "Owner@gmail.com", Firstname = "Owner", Lastname = "Ownerov", Role = UserRoles.Owner,
                    PasswordHash = passwordHash, PasswordSalt = passwordSalt
                }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 3, 
                    Email = "Admin@gmail.com", 
                    Firstname = "Admin", 
                    Lastname = "Adminov", 
                    PasswordHash = passwordHash, 
                    PasswordSalt = passwordSalt
                }
            );

            modelBuilder.Entity<Seller>().HasData(
                new Seller()
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
                    Avatar = "https://localhost:5001/UploadedAvatar/51d61b2ed0f345dfb236663d9c9df35d.png",
                    Role = UserRoles.Seller,
                    Description = null,
                    AdAccount = null,
                    Products = null,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                },
                new Seller()
                {
                    Id = 5,
                    Email = "Seller1@gmail.com",
                    Firstname = "Seller1",
                    Lastname = "Sellerov1",
                    Role = UserRoles.Seller,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Username = "Seller",
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
                    BrandId = 1,
                    Type = TypeConditioner.InnerBlock
                    
                },
                new Conditioner
                {
                    Id = 2,
                    SellerId = 5,
                    CategoryId = 12,
                    BrandId = 1,
                    Type = TypeConditioner.InnerBlock

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
                    CategoryId = 4,
                    LoopType = LoopType.Automatic,
                    BrandId = 4
                }
            );
            
            modelBuilder.Entity<ProductPhoto>().HasData(
                new ProductPhoto
                {
                    Name = "1541c61918574865b4c8447432440be1.png",
                    UrlPath = "https://localhost:5001/UploadedProductsPhotos/1541c61918574865b4c8447432440be1.png",
                    TimeStamp = DateTime.Now,
                    Id = 1,
                    ProductId = 1,

                }
            );
            // TODO test
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Samsung",
                });
            
            modelBuilder.Entity<School>().HasData(
                new School()
                {
                    Id = 2,
                    Name = "Samsung",
                    Number = 4
                });
            
            modelBuilder.Entity<TestEmployee>().HasData(
                new TestEmployee
                {
                    Id = 1,
                    Name = "Genadiy",
                    Lastname = "Asmanov",
                    ExtraId = 1,
                },
                new TestEmployee
                {
                    Id = 2,
                    Name = "Arsen",
                    Lastname = "Masabirov",
                    ExtraId = 2,
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