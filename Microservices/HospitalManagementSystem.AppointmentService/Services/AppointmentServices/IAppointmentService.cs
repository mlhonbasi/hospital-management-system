using HospitalManagementSystem.AppointmentService.Dtos.AppointmentDtos;

namespace HospitalManagementSystem.AppointmentService.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        public Task<List<ResultAppointmentDto>> GetAllAsync();
        public Task<GetAppointmentByIdDto> GetByIdAsync(int id);
        public Task CreateAsync(CreateAppointmentDto dto);
        public Task UpdateAsync(UpdateAppointmentDto dto);
        public Task DeleteAsync(int id);
    }
}
