using HospitalManagementSystem.IdentityService.Dtos;

namespace HospitalManagementSystem.IdentityService.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleDto dto);
    }
}
