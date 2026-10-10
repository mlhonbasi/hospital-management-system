using HospitalManagementSystem.WebUI.Dtos.BranchDtos;

namespace HospitalManagementSystem.WebUI.Services.BranchServices
{
    public interface IBranchService
    {
        Task<List<ResultBranchDto>> GetAllBranchesAsync();
        Task CreateBranchAsync(CreateBranchDto dto);
        Task UpdateBranchAsync(UpdateBranchDto dto);
        Task DeleteBranchAsync(string id);
        Task<GetByIdBranchDto> GetBranchByIdAsync(string id);
    }
}
