using MegaMarketMall.Models.Dto;
using MegaMarketMall.Models.Users;

namespace MegaMarketMall.Services.Methods
{
    public static class UserMethods
    {
        public static User CreateUser(RegisterUserDto userDto)
        {
            PasswordMethods.CreatePasswordHashSalt(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            return new User
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Phone = userDto.Phone,
                Firstname = userDto.Firstname,
                Lastname = userDto.Lastname,
                Patronymic = userDto.Patronymic,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }
    }
}