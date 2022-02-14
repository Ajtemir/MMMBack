using System;
using System.IO;
using System.Threading.Tasks;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Dto;
using MegaMarketMall.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MegaMarketMall.Services.Methods;

namespace MegaMarketMall.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _environment;


        public UserController(ApplicationContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Registration([FromForm]RegisterUserDto request) // TODO Avatar upload
        {
            if (await _context.Users.AnyAsync(u => u.Email.Equals(request.Email)))
                return BadRequest("Email address is already consist");
            string avatar = null;
            if (request.Avatar is not null)
            {
                var file = request.Avatar;
                const string directory = "/UploadedUsersAvatar/";
                if (!Directory.Exists(_environment.WebRootPath + directory))
                    Directory.CreateDirectory(_environment.WebRootPath + directory);
                
                string fileName = Guid.NewGuid().ToString().Replace("-", "") + System.IO.Path.GetExtension(file.FileName);
                await using var fileStream = System.IO.File.Create(_environment.WebRootPath + directory + fileName);
                await file.CopyToAsync(fileStream);
                fileStream.Flush();
                avatar = Request.Scheme + "://" + Request.Host + directory + fileName;
            }

            User user = UserMethods.CreateUser(request);
            user.Avatar = avatar;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User has been registered successfully");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return Ok(allUsers);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> AuthUser(AuthUserDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(userDto.Email));
            if (user is null)
                return BadRequest("User not found");
            if (!PasswordMethods.VerifyPasswordHash(userDto, user))
                return BadRequest("Wrong Password");
            return Ok();
        }
    }
    
    
}