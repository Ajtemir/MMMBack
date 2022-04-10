using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.Dtos
{
    public class RefreshTokenRequest
    {
        [Required] public string ExpiredToken { get; set; }
        [Required] public string RefreshToken { get; set; }
    }
}