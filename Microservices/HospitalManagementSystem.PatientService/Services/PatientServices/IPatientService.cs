using HospitalManagementSystem.PatientService.Dtos.PatientDtos;

namespace HospitalManagementSystem.PatientService.Services.PatientServices
{
    public interface IPatientService
    {
        public Task<List<ResultPatientDto>> GetAllPatientsAsync();
    }
}
