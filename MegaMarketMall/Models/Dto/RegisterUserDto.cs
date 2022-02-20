using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Attributes;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Dto
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; } 
        [Required]
        [StringLength(20, ErrorMessage = "Must be between 8 and 20 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&-])[A-Za-z\d@$!%*#?&-]{8,20}$")] // TODO add more special characters
        public string Password { get; set; }

        [FileAttributes.MaxFileSizeAttribute(5 * 1024 * 1024)]
        [FileAttributes.AllowedExtensionsAttribute(new [] {".jpg", ".png"})]
        public IFormFile Avatar { get; set; } = null;

        public string AvatarPath {internal get; set; } = null;

        public string Username { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Patronymic { get; set; } = null;
    }
}