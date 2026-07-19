using HospitalManagementSystem.IdentityService.Context;
using HospitalManagementSystem.IdentityService.Dtos;
using HospitalManagementSystem.IdentityService.Entities;
using HospitalManagementSystem.IdentityService.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HospitalManagementSystem.IdentityService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
                return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

            if (!result.Succeeded)
                return null;

            return await GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                UserName = dto.Username,
                Email = dto.Email,
                City = dto.City,
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            return result.Succeeded;
        }

        private async Task<string> GenerateToken(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim("name", user.Name ?? ""),
                new Claim("surname", user.Surname ?? "")
            };

            foreach (var item in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes!),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
