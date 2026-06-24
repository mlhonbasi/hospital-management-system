using AutoMapper;
using HospitalManagementSystem.DoctorService.Dtos.DoctorDtos;
using HospitalManagementSystem.DoctorService.Entities;

namespace HospitalManagementSystem.DoctorService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Doctor, CreateDoctorDto>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorByIdDto>().ReverseMap();
            CreateMap<Doctor, ResultDoctorDto>().ReverseMap();
            CreateMap<Award, AwardDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
