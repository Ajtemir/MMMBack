using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Models.Users
{
    public class Seller
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = null;
        public string Description { get; set; } = null;
        public int? AdAccount { get; set; } = null;
        public int UserId { get; set; }
        public string Avatar { get; set; } = null;
        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<Product> Products { get; set; } = new();
        
        //Todo подумать об проходах и контейерах
        public string Location { get; set; } = null; 
        // public string Section { get; set; }
        // public string Path { get; set; }
        // public string Number { get; set; }
    }
}