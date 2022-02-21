using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.Dtos
{
    public class AuthRequest
    {
        [Required]
        public string Email { get; set; } 
        [Required]
        public string Password { get; set; } 
    }
}