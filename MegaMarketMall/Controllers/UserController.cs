using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MegaMarketMall.Context;
using MegaMarketMall.Dtos;
using MegaMarketMall.Extensions;
using MegaMarketMall.Methods;
using MegaMarketMall.Models;
using MegaMarketMall.Models.Tokens;
using MegaMarketMall.Models.Users;
using MegaMarketMall.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IJwtService _jwtService;


        public UserController(ApplicationContext context, IWebHostEnvironment environment, IJwtService jwtService)
        {
            _context = context;
            _environment = environment;
            _jwtService = jwtService;
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
        [Authorize(Roles = "Seller")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return Ok(allUsers);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<string>> AuthUser(AuthRequest request)
        {
            var user = await _context.Users.
                FirstOrDefaultAsync(u => u.Email.Equals(request.Email));
            if (user is null)
                return BadRequest("User not found");
            if(!user.CheckPassword(request.Password))
                return BadRequest("Wrong Password");
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var authResponse = await _jwtService.GetBothTokensAsync(user, ipAddress);
            if (authResponse is null)
                return Unauthorized();
            return Ok(authResponse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResponse{IsSuccess = false, Reason = "Tokens must be provided"});
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var token = GetJwtToken(request.ExpiredToken);
            var userRefreshToken = _context.UserRefreshTokens.FirstOrDefault(
                x => x.IsInvalidated == false && x.AccessToken == request.ExpiredToken
                                              && x.RefreshToken == request.RefreshToken
                                              && x.IpAddress == ipAddress);
            AuthResponse response = ValidateDetails(token, userRefreshToken);
            if (!response.IsSuccess)
                return BadRequest(response);
            userRefreshToken.IsInvalidated = true;
            _context.UserRefreshTokens.Update(userRefreshToken);
            await _context.SaveChangesAsync();
            
            var email = token.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email)?.Value;
            Console.WriteLine(email); // TODO remove
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            var authResponse = await _jwtService.GetRefreshTokenAsync(user,ipAddress);
            return Ok(authResponse);
        }

        private AuthResponse ValidateDetails(JwtSecurityToken token, UserRefreshToken userRefreshToken)
        {
            Console.WriteLine($"{token.ValidTo} > {DateTime.UtcNow}"); //TODO remove

            if (userRefreshToken == null)
                return new AuthResponse() {IsSuccess = false, Reason = "Invalid Token Details."};
            if (token.ValidTo > DateTime.UtcNow) //TODO utc 
                return new AuthResponse() {IsSuccess = false, Reason = "Token not expired."};
            if (!userRefreshToken.IsActive)
                return new AuthResponse() {IsSuccess = false, Reason = "Refresh Token Expired."};
            return new AuthResponse() {IsSuccess = true};


        }
        private JwtSecurityToken GetJwtToken(string expiredToken)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.ReadJwtToken(expiredToken);
        }
    }
    
    
}