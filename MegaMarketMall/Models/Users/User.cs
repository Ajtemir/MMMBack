using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MegaMarketMall.Data.Constants;
using MegaMarketMall.Data.Enums.User;
using MegaMarketMall.Data.Methods;
// using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MegaMarketMall.Models.Users
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public User(string email,string password)
        {
            PasswordMethods.CreatePasswordHashSalt(password,out var passwordHash, out var passwordSalt);
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public User(){}
        private readonly string _email;

        [Required]
        public string Email
        {
            get => _email;
            init => _email = value?.ToLower();
        }
        
        [Required] [JsonIgnore] public byte[] PasswordHash { get; init; }
        [Required] [JsonIgnore] public byte[] PasswordSalt { get; init; }
        [JsonIgnore] public int Id { get; set; }
        public string Username { get; set; } = null;
        public string Phone { get; set; } = null;
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Patronymic { get; set; } = null;
        
        [JsonIgnore] public bool IsActive { get; set; } = true; // Todo подумать об активности или через почту
        [JsonIgnore] public virtual string Role { get; set; } = UserRoles.User;

        public bool IsDeleted { get; set; } = false;

        public string Avatar { get; set; } = null;
        // public Seller Seller { get; set; }

        // public List<Seller> Sellers { get; set; } = null;
        // public string Password { internal get; set; } // TODO => without hashing
        // TODO => make salt
        // TODO => TimeStamp
        // TODO => IsDeleted
    }
}