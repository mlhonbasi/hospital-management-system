using HospitalManagementSystem.WebUI.Dtos.PatientDtos;

namespace HospitalManagementSystem.WebUI.Services.PatientServices
{
    public interface IPatientService
    {
        Task<List<ResultPatientDto>> GetAllPatientsAsync();
    }
}
