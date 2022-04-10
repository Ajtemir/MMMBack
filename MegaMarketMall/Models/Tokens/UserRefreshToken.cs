using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Models.Tokens
{
    [Table(("UserRefreshToken"))]
    public class UserRefreshToken
    {
        [Key]
        public int Id { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        [NotMapped]
        public bool IsActive => ExpirationDate > DateTime.UtcNow;
        
        public string IpAddress { get; set; }
        public bool IsInvalidated { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        
    }
}