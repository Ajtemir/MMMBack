using System.ComponentModel.DataAnnotations.Schema;

namespace MegaMarketMall.TestData
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int FId { get; set; }
        // [ForeignKey("FId")] public virtual TestPerson TestPerson { get; set; }
    }
}