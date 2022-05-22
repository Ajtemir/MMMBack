using System.ComponentModel.DataAnnotations;

namespace MegaMarketMall.Areas.Admin.ViewModels
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "no email specified")]
        public string Email { get; set; }
        [Required(ErrorMessage = "No password specified")]
        
        public string Password { get; set; }
    }
}