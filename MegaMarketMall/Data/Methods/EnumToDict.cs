using System;
using System.Collections.Generic;

namespace MegaMarketMall.Data.Methods
{
    public class EnumToDict
    {
        public static Dictionary<int,T> ConvertEnumToDict<T>(Type type) where T: Enum
        {
            Dictionary<int, T> dict = new();
            foreach( T property in Enum.GetValues(type))
                dict.Add(Convert.ToInt32(property), property);
            return dict;
        }
        
    }
}