using HospitalManagementSystem.BranchService.Dtos.BranchDtos;

namespace HospitalManagementSystem.BranchService.Services
{
    public interface IBranchService
    {
        public Task<List<ResultBranchDto>> GetAllAsync();
        public Task<GetBranchByIdDto> GetByIdAsync(string id);
        public Task CreateAsync(CreateBranchDto dto);
        public Task UpdateAsync(UpdateBranchDto dto);
        public Task DeleteAsync(string id);
    }
}
