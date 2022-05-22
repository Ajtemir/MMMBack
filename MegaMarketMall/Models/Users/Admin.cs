using System.ComponentModel.DataAnnotations.Schema;
using MegaMarketMall.Data.Constants;

namespace MegaMarketMall.Models.Users
{
    [Table("Admin")]
    public class Admin : User
    {
        public Admin(string email,string password):base(email,password){}
        public Admin(){}
        public override string Role { get; set; } = UserRoles.Admin;
    }
}