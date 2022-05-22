using MegaMarketMall.Data.Interfaces.Get;

namespace MegaMarketMall.Data.Methods
{
    public static class PageFromIPage
    {
        public static int GetPage(IPage page)
        {
            if (page.Page.HasValue)
                return page.Page.Value >= 0 ? page.Page.Value : 1;
            return 1;
        }
    }
}