using System;
using System.Collections.Generic;
using MegaMarketMall.Controllers;
using MegaMarketMall.Data.Enums.Conditioner;
using MegaMarketMall.Data.Methods;

namespace MegaMarketMall.Data.Constants
{
    public static class ProductAttributeConstants
    {
        public static readonly Dictionary<string,Type> DictEnums = new()
        {
            // Conditioner
            {nameof(TypeConditioner).ToLower(),typeof(TypeConditioner)},
            {nameof(MountingTheIndoorUnit).ToLower(),typeof(MountingTheIndoorUnit)},
            {nameof(TypeCompressor).ToLower(),typeof(TypeCompressor)},
            {nameof(RecommendedAreaSquareMeter).ToLower(),typeof(RecommendedAreaSquareMeter)},
            
            // 
            
            
            
        };
        
        
    }
}