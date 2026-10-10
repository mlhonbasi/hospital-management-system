using HospitalManagementSystem.WebUI.Dtos.LoginDtos;

namespace HospitalManagementSystem.WebUI.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<string> LoginAsync(LoginDto dto);
    }
}
