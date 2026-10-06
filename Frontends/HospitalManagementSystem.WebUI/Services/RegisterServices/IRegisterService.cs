using HospitalManagementSystem.WebUI.Models.Auth;

namespace HospitalManagementSystem.WebUI.Services.RegisterServices
{
    public interface IRegisterService
    {
        Task<bool> RegisterAsync(RegisterViewModel model);
    }
}
