using HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos;

namespace HospitalManagementSystem.PrescriptionService.Services
{
    public interface IPrescriptionService
    {
        public Task CreateAsync(CreatePrescriptionDto dto);
        public Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int id);
        public Task<List<ResultPrescriptionDto>> GetByPatiendIdAsync(int id);
        public Task<ResultPrescriptionDto> GetByIdAsync(int id);
    }
}
