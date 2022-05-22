using MegaMarketMall.Data.Interfaces.Product;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MegaMarketMall.Data.Extensions
{
    public static class DeliverExtension
    {
        public static string GetDeliverString(this IDeliver deliver)
        {
            var extracted = deliver.IsDelivered;
            if (extracted.HasValue)
            {
                var flag = (bool)extracted.Value;
                return flag ? "Бесплатная доставка" : "Платная доставка";
            }

            return "Самовызов";

        }
    }
}