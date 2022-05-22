using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Data.Constants;
using DataType = Swashbuckle.AspNetCore.SwaggerGen.DataType;

namespace MegaMarketMall.Areas.Admin.ViewModels
{
    public class LoginAdminViewModel
    {
        [Required(ErrorMessage = "no email specified")]
        [EmailAddress(ErrorMessage = "email's format is wrong")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "No password specified")]
        public string Password { get; set; }
    }
}