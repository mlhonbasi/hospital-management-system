using AutoMapper;
using HospitalManagementSystem.AppointmentService.Context;
using HospitalManagementSystem.AppointmentService.Dtos.AppointmentDtos;
using HospitalManagementSystem.AppointmentService.Entitites;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.AppointmentService.Services.AppointmentServices
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentService(AppointmentContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;   
        }
        public async Task CreateAsync(CreateAppointmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);
            value.Status = "Pending";

            _dbContext.Add(value);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var value = await _dbContext.Appointments.FindAsync(id);
            _dbContext.Appointments.Remove(value);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ResultAppointmentDto>> GetAllAsync()
        {
            var values = await _dbContext.Appointments.ToListAsync();
            return _mapper.Map<List<ResultAppointmentDto>>(values);
        }

        public async Task<GetAppointmentByIdDto> GetByIdAsync(int id)
        {
            var value = await _dbContext.Appointments.FindAsync(id);
            return _mapper.Map<GetAppointmentByIdDto>(value);
        }

        public async Task UpdateAsync(UpdateAppointmentDto dto)
        {
            var value = _mapper.Map<Appointment>(dto);
            _dbContext.Appointments.Update(value);
            await _dbContext.SaveChangesAsync();
        }
    }
}
