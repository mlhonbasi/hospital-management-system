using AutoMapper;
using HospitalManagementSystem.AppointmentService.Context;
using HospitalManagementSystem.AppointmentService.Dtos.AppointmetDetailDtos;
using HospitalManagementSystem.AppointmentService.Entitites;

namespace HospitalManagementSystem.AppointmentService.Services.AppointmentDetailServices
{
    public class AppointmentDetailService : IAppointmentDetailService
    {
        private readonly AppointmentContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentDetailService(AppointmentContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateAppointmentDetailDto dto)
        {
            var value = _mapper.Map<AppointmentDetail>(dto);
            _dbContext.AppointmentDetails.Add(value);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ResultAppointmentDetailDto> GetByAppointmentId(int id)
        {
            var value = await _dbContext.AppointmentDetails.FindAsync(id);
            return _mapper.Map<ResultAppointmentDetailDto>(value);
        }

        public async Task UpdateAsync(UpdateAppointmentDetailDto dto)
        {
            var value = await _dbContext.AppointmentDetails.FindAsync(dto.AppointmentDetailId);

            if (value == null)
                return;

            value.Complaint = dto.Complaint;
            value.Notes = dto.Notes;
            value.Diagnosis = dto.Diagnosis;
            value.Prescription = dto.Prescription;

            _dbContext.AppointmentDetails.Update(value);
            await _dbContext.SaveChangesAsync();
        }
    }
}
