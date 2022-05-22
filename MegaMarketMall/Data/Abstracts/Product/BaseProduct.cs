using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MegaMarketMall.Data.Extensions;
using MegaMarketMall.Data.Interfaces.Product;
using MegaMarketMall.Models.ProductPhotos;
using MegaMarketMall.Models.Products;
using Newtonsoft.Json;

namespace MegaMarketMall.Data.Abstracts.Product
{
    public abstract class BaseProduct : IEntity, ISellerId, ICategoryId
    {
        public string Description { get; set; } = null;
        public int? Price { get; set; } = null;
        [JsonIgnore]
        public bool? IsDelivered { get; set; } = null;
        [JsonIgnore]
        public virtual List<ProductPhoto> Photos { get; set; }
        [JsonIgnore]
        public int SellerId { get; set; }
        [JsonIgnore]

        public int CategoryId { get; set; }
        [JsonIgnore]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

        [JsonProperty("timeStamp")]
        public string TimeStampDay => TimeStamp.ToString("dd/MM/yyyy");
        public string Deliver => this.GetDeliverString();
        // [JsonProperty("photos")] public List<string> PhotosUrls => Photos.Select(p => p.UrlPath).ToList();


    }
}