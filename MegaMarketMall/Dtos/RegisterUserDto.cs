using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Data.Attributes;
using MegaMarketMall.Data.Interfaces.Avatar;
using Microsoft.AspNetCore.Http;

namespace MegaMarketMall.Dtos
{
    public class RegisterUserDto : IAvatar
    {
        [Required]
        public string Email { get; set; } 
        [Required]
        [StringLength(20, ErrorMessage = "Must be between 8 and 20 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&-])[A-Za-z\d@$!%*#?&-]{8,20}$")] // TODO add more special characters
        public string Password { get; set; }

        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new [] {".jpg", ".png"})]
        public IFormFile Avatar { get; set; } = null;

        public string AvatarPath {internal get; set; } = null;

        public string Username { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Patronymic { get; set; } = null;
    }
}