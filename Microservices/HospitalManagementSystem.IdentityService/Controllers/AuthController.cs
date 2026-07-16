using HospitalManagementSystem.IdentityService.Dtos;
using HospitalManagementSystem.IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (!result)
                return BadRequest("Kullanıcı olusturulamadı.");
            return Ok("Kullanıcı basarıyla olusturuldu.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);

            if (token == null)
                return BadRequest("Kullanıcı e-posta veya şifre hatalı.");

            return Ok(new { token });
        } 
    }
}
