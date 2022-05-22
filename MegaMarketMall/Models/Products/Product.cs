using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using MegaMarketMall.Data.Abstracts.Product;
using MegaMarketMall.Dtos.Response.ProductView;
using MegaMarketMall.Models.Categories;
using MegaMarketMall.Models.Users;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Products
{
    public class Product : BaseProduct
    {
        public int Views { get;internal set; }
        public int Favorites { get;internal set; }

        [Key]
        public int Id { get;internal set; }
        
        [JsonIgnore]
        public bool IsDeleted {  get;  set; } = false;
        [JsonIgnore]
        public bool? IsActive { get; set; } = true;
        [JsonIgnore]
        public bool AdStatus { get; set; } = false;
        [JsonIgnore]
        [ForeignKey("SellerId")]
        
        public virtual User Seller { get; set; }
        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        // public string SellerPhone => Seller?.Phone;
        // public string CategoryName => Category?.Name;
        [JsonProperty("Photos")]
        public List<string> PhotosUrls => Photos?.Select(p => p.UrlPath).ToList();

        [JsonProperty("Seller")]

        public SellerView SellerView => new SellerView
        {
            Avatar = Seller.Avatar,
            Phone = Seller.Phone,
            Username = Seller.Username
        };
        [JsonProperty("Category")]
        public string CategoryName => Category?.Name;

        //Todo подумать как реализовать скидку discount
        //Todo created updated
    }

    
}