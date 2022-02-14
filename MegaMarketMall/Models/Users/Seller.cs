using System;
using System.Collections.Generic;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.Models.Users
{
    public class Seller
    {
        public int Id { get; set; }
        public string Nickname { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public uint? AdAccount { get; set; } = null;
        public int UserId { get; set; }
        public string Avatar { get; set; }
        public User Owner { get; set; }
        public List<Product> Products { get; set; } = new();
        
        //Todo подумать об проходах и контейерах
        public string Location { get; set; } = String.Empty; 
        // public string Section { get; set; }
        // public string Path { get; set; }
        // public string Number { get; set; }
    }
}