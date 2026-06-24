using HospitalManagementSystem.ReviewService.Dtos.ReviewDtos;

namespace HospitalManagementSystem.ReviewService.Services
{
    public interface IReviewService
    {
        Task CreateReviewAsync(CreateReviewDto dto);
        Task<GetReviewByIdDto> GetReviewByIdAsync(string id);
        Task<List<ResultReviewDto>> GetAllAsync();
        Task DeleteAsync(string id);
    }
}
