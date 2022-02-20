using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; } = null; // null отсуствует описание
        public bool? IsActive { get; set; } = true; //Todo => подумать об дефолтном значении null==moderation
        public uint? Price { get; set; } = null; // null договорная
        public bool? IsDelivered { get; set; } = null; //TODO => подумать об доставке null=самовызов true=беслатная false=платная

        public bool IsDeleted { get; set; } = false;
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        
        public uint Views { get; set; } = 0;
        public ulong Favorites { get; set; } = 0;
        public int? AdStatus { get; set; } = null; // null = ни разу не пополнял
        public bool IsNew { get; set; } = true;
        
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        // public string Name { get; set; } = string.Empty;


        public List<ProductPhoto> Photos { get; set; } = null; //null 
        //Todo подумать как реализовать скидку discount
        //Todo Photos property
        
    }
}