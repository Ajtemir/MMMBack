using System;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Products;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.ProductPhotos
{
    public class ProductPhoto
    {
        [JsonIgnore]
        public string Name { get; set; }
        public string UrlPath { get; set; }
        [JsonIgnore]
        public DateTime TimeStamp { get; set; } = DateTime.Now; 
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int? ProductId { get; set; }
        [JsonIgnore,ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [JsonIgnore] public bool IsDeleted { get; set; } = false;
    }
}