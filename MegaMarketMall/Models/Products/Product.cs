using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool? IsActive { get; set; } = true; //Todo => подумать об дефолтном значении null==moderation
        public uint? Price { get; set; } = null;
        public bool? IsDelivered { get; set; } = null; //TODO => подумать об доставке null=самовызов
        public uint SellerId { get; set; }
        public uint CategoryId { get; set; }
        public Seller Seller { get; set; }
        public Category Category { get; set; }
        public uint Views { get; set; } = 0;
        public ulong Favorites { get; set; } = 0;
        public int? AdStatus { get; set; } = null;
        public bool IsNew { get; set; } = true;

        public List<ProductPhoto> Photos { get; set; } = null;
        //Todo подумать как реализовать скидку discount
        //Todo Photos property
        //TODO ViewsCount property
        //TODO FavoriteCount property
        //TODO Ad status property
    }
}