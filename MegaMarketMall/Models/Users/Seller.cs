using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Enums.Seller;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Models.Users
{
    [Table("Seller")]
    public class Seller : User
    {
        public string Description { get; set; } = null;
        public int? AdAccount { get; set; } = null;
        public override string Role { get; set; } = UserRoles.Seller;
        public SellerType Type { get; set; } = SellerType.Online;
        public virtual Address Address { get; set; } = null;
        public virtual ShopPlace ShopPlace { get; set; } = null;
        public virtual List<Product> Products { get; set; } = new();
        

        

        //Todo подумать об проходах и контейерах
        // public int UserId { get; set; }
        // public string Avatar { get; set; } = null;
        // [ForeignKey("UserId")]
        // public User User { get; set; }
        // public string Section { get; set; }
        // public string Path { get; set; }
        // public string Number { get; set; }
    }
}