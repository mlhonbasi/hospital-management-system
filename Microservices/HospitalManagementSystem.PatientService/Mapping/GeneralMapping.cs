using AutoMapper;
using HospitalManagementSystem.PatientService.Dtos.PatientDtos;
using HospitalManagementSystem.PatientService.Entities;

namespace HospitalManagementSystem.PatientService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Patient, ResultPatientDto>();
        }
    }
}
