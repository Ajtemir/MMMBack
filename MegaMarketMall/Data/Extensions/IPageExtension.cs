using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Data.Extensions
{
    public static class PageExtension
    {
        public static int GetPage(this IPage page)
        {
            if (page.Page.HasValue)
                return page.Page.Value >= 0 ? page.Page.Value : 1;
            return 1;
        }
    }
}