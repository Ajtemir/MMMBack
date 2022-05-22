using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Data.Constants;

namespace MegaMarketMall.Areas.Admin.ViewModels
{
    public class RegisterAdminViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(PasswordRegex.Regex,ErrorMessage = PasswordRegex.RegexErrorMessage)]
        public string Password { get; set; }
    }
}