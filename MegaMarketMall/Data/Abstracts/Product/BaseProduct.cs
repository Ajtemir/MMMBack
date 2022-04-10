using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.Products;
using Newtonsoft.Json;

namespace MegaMarketMall.Data.Abstracts.Product
{
    public abstract class BaseProduct : IEntity, ISellerId, ICategoryId
    {
        public string Description { get; set; } = null;
        public uint? Price { get; set; } = null;
        public bool? IsDelivered { get; set; } = null;
        public List<ProductPhoto> Photos { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        [JsonProperty("Создано")] public string TimeStampDay => TimeStamp.ToString("dd/MM/yyyy");


    }
}