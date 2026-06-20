using AutoMapper;
using HospitalManagementSystem.BranchService.Dtos.BranchDtos;
using HospitalManagementSystem.BranchService.Entities;

namespace HospitalManagementSystem.BranchService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Branch, ResultBranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            CreateMap<Branch, UpdateBranchDto>().ReverseMap();
            CreateMap<Branch, GetBranchByIdDto>().ReverseMap();
        }
        
    }
}
