using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Extensions;
using MegaMarketMall.Methods;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Dto;
using MegaMarketMall.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (request.Avatar is not null)
                request.AvatarPath = await UserMethods.CreateFilePath(request.Avatar,_environment,Request);
            var user = UserMethods.CreateUser(request);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok("User has been registered successfully");
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return Ok(allUsers);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> AuthUser(AuthRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(request.Email));
            if (user is null)
                return BadRequest("User not found");
            if(!user.CheckPassword(request.Password))
                return BadRequest("Wrong Password");
            // if (!PasswordMethods.VerifyPasswordHash(request, user))
            //     return BadRequest("Wrong Password");
            return Ok();
        }
    }
    
    
}