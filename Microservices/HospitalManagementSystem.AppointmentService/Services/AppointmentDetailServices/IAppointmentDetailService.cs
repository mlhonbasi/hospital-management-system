using HospitalManagementSystem.AppointmentService.Dtos.AppointmetDetailDtos;

namespace HospitalManagementSystem.AppointmentService.Services.AppointmentDetailServices
{
    public interface IAppointmentDetailService
    {
        Task CreateAsync(CreateAppointmentDetailDto dto);
        Task UpdateAsync(UpdateAppointmentDetailDto dto);
        Task<ResultAppointmentDetailDto> GetByAppointmentId(int id);
    }
}
