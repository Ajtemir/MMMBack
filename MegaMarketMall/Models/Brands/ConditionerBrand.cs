using System.Collections.Generic;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments;
using MegaMarketMall.Models.Products.Cluster.Electronics.HouseHoldAppliances.Climatic_Equipments.Conditioner;

namespace MegaMarketMall.Models.Brands
{
    public class ConditionerBrand : Brand
    {
        public List<Conditioner> Products { get; set; }
    }
}