using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMarketMall.TestData
{
    [Table(nameof(SellerTest))]
    public class SellerTest : UserTest
    {
        public int Account { get; set; } = int.MinValue;
    }
}