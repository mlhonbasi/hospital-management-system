using AutoMapper;
using HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos;
using HospitalManagementSystem.PrescriptionService.Entities;

namespace HospitalManagementSystem.PrescriptionService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreatePrescriptionDto, Prescription>();
            CreateMap<Prescription, ResultPrescriptionDto>();
            CreateMap<PrescriptionItem, PrescriptionItemDto>().ReverseMap();
        }
    }
}
