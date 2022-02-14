using System;
using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.TestData
{
    public class UserTest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [Required]
        public string RName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = null;
        public string RLastName { get; set; } = null;
        public string Username { get; set; }
        [Required] public int? Age { get; set; } = null;
        public string Patronymic { get; set; } = null;
    }
}