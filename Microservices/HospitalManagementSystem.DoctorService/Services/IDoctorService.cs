using HospitalManagementSystem.DoctorService.Dtos.DoctorDtos;

namespace HospitalManagementSystem.DoctorService.Services
{
    public interface IDoctorService
    {
        public Task<List<ResultDoctorDto>> GetAllAsync();
        public Task<GetDoctorByIdDto> GetDoctorByIdAsync(string id);
        public Task CreateAsync(CreateDoctorDto dto);
        public Task UpdateAsync(UpdateDoctorDto dto);
        public Task DeleteAsync(string id);
    }
}
