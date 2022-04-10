using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Statuses? Status { internal get; set; } = null;
        public string Stat => Status.ToString();

        

        public enum Statuses
        {
            member=1,
            employee,
            teacher
        }
        
    }
}