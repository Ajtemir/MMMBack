using MegaMarketMall.Context;
using MegaMarketMall.Models.Products;

namespace MegaMarketMall.TestData
{
    public class TestService : ITestService
    {
        private readonly ApplicationContext _context;

        public TestService(ApplicationContext context)
        {
            _context = context;
        }

        public void Get<T>(TestGet query) where T : Product
        {
            
        }
    }
}