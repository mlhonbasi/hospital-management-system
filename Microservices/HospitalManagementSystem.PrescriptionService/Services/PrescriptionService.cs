using AutoMapper;
using HospitalManagementSystem.PrescriptionService.Context;
using HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos;
using HospitalManagementSystem.PrescriptionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.PrescriptionService.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly PrescriptionContext _dbContext;
        private readonly IMapper _mapper;

        public PrescriptionService(IMapper mapper, PrescriptionContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task CreateAsync(CreatePrescriptionDto dto)
        {
            var entity = new Prescription
            {
                AppointmentId = dto.AppointmentId,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                CreatedDate = DateTime.UtcNow,

                PrescriptionItems = dto.PrescriptionItems.Select(x => new PrescriptionItem
                {
                    Duration = x.Duration,
                    MedicineName = x.MedicineName,
                    Usage = x.Usage,
                }).ToList(),
            };

            _dbContext.Prescriptions.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ResultPrescriptionDto> GetByAppointmentIdAsync(int appointmentId)
        {
            var value = await _dbContext.Prescriptions
                .Include(x => x.PrescriptionItems)
                .FirstOrDefaultAsync(x=> x.AppointmentId == appointmentId);

            return _mapper.Map<ResultPrescriptionDto>(value);
        }

        public async Task<ResultPrescriptionDto> GetByIdAsync(int id)
        {
            var value = await _dbContext.Prescriptions
                .Include(x => x.PrescriptionItems)
                .FirstOrDefaultAsync(x => x.PrescriptionId == id);

            return _mapper.Map<ResultPrescriptionDto>(value);
        }

        public async Task<List<ResultPrescriptionDto>> GetByPatiendIdAsync(int patientId)
        {
            var value = await _dbContext.Prescriptions
                .Include(x => x.PrescriptionItems)
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            return _mapper.Map<List<ResultPrescriptionDto>>(value);
        }
    }
}
