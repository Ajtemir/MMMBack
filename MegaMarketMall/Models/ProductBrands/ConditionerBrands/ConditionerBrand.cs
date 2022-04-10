using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Interfaces.Brand;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;

namespace MegaMarketMall.Models.ProductBrands.Conditionerbrands
{
    // public class ConditionerBrand<T> : ProductBrand<T>
    // {}
    
    public class ConditionerBrand : IProductBrand<Conditioner>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<Conditioner> Products { get; set; } = new();
    }
}