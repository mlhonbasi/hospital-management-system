using AutoMapper;
using HospitalManagementSystem.AppointmentService.Dtos.AppointmentDtos;
using HospitalManagementSystem.AppointmentService.Dtos.AppointmetDetailDtos;
using HospitalManagementSystem.AppointmentService.Entitites;

namespace HospitalManagementSystem.AppointmentService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();
            CreateMap<Appointment, GetAppointmentByIdDto>().ReverseMap();
            CreateMap<Appointment, ResultAppointmentDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentDto>().ReverseMap();

            CreateMap<AppointmentDetail, CreateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, UpdateAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, ResultAppointmentDetailDto>().ReverseMap();
            CreateMap<AppointmentDetail, GetAppointmentDetailById>().ReverseMap();
        }
    }
}
