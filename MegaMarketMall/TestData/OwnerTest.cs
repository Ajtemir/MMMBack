using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMarketMall.TestData
{
    [Table(nameof(OwnerTest))]
    public class OwnerTest : SellerTest
    {
        public int Bought { get; set; }
    }
}