using AutoMapper;
using HospitalManagementSystem.ReviewService.Dtos.ReviewDtos;
using HospitalManagementSystem.ReviewService.Entities;

namespace HospitalManagementSystem.ReviewService.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, GetReviewByIdDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
        }
    }
}
