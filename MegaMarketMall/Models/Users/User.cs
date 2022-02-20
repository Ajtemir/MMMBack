using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Users
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Required] public string Email { get; set; }
        [Required] [JsonIgnore] public byte[] PasswordHash { get; set; }
        [Required] [JsonIgnore] public byte[] PasswordSalt { get; set; }
        [JsonIgnore] public int Id { get; set; }
        public string Username { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Patronymic { get; set; } = null;
        
        [JsonIgnore] public bool IsActive { get; set; } = true; // Todo подумать об активности или через почту
        [JsonIgnore] public string Role { get; set; } = "User";

        public bool IsDeleted { get; set; } = false;

        public string Avatar { get; set; } = null;

        public List<Seller> Sellers { get; set; } = null;
        // public string Password { internal get; set; } // TODO => without hashing
        // TODO => make salt
        // TODO => TimeStamp
        // TODO => IsDeleted
    }
}