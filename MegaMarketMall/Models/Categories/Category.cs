using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
// using System.Text.Json.Serialization;
using MegaMarketMall.Models.Products;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Categories
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        public string Name { get; set; }
        [JsonIgnore]
        public uint Count { get; set; } = UInt32.MinValue;
        public int? ParentCategoryId { internal get; set; }
        [JsonIgnore]
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }

        [NotMapped] public string ParentCategoryName => ParentCategory?.Name;
        [JsonIgnore]
        public List<Category> SubCategories { get; set; } = new();
        [JsonIgnore]
        public List<Product> Products { get; set; } = new();

        [NotMapped] public bool IsParent => SubCategories.Any();
        //TODO think about IsParent
    }
}