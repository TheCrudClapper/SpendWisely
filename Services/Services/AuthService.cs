using Entities.DatabaseContexts;
using Entities.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Dtos;
using Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        public AuthService(DatabaseContext context, UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _context = context;
            _userManager = userManager;
            _config = config;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Email already in use." }
                };
            }
            var token = GenenerateJwtToken(user);
            return new AuthResponseDto { Success = true, Token = token };
                
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = new List<string> { "Email already in use." }
                };
            }
            var user = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                DateCreated = DateTime.Now,
                IsActive = true,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }
            return new AuthResponseDto { Success = true };
        }

        public string GenenerateJwtToken(ApplicationUser user)
        {
            var jwtKey = _config["Jwt:Key"];
            var jwtIssuer = _config["Jwt:Issuer"];
            var jwtAudience = _config["Jwt:Audience"];

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
