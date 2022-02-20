using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.Models.Dto
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; } 
    }
}