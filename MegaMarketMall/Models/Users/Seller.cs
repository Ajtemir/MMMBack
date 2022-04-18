using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Models.Users
{
    [Table("Seller")]
    public class Seller : User
    {
        public string Nickname { get; set; } = null;
        public string Description { get; set; } = null;
        public int? AdAccount { get; set; } = null;
        public override string Role { get; set; } = "Seller";
        public List<Product> Products { get; set; } = new();
        // public string Location { get; set; } = null;


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