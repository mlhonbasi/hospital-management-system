using HospitalManagementSystem.IdentityService.Dtos;

namespace HospitalManagementSystem.IdentityService.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto dto);
        Task<bool> LoginAsync(LoginDto dto);
    }
}
