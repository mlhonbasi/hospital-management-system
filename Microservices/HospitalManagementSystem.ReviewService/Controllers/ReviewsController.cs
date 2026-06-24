using HospitalManagementSystem.ReviewService.Dtos.ReviewDtos;
using HospitalManagementSystem.ReviewService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController(IReviewService _reviewService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRevies()
        {
            var values = await _reviewService.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(string id)
        {
            var value = _reviewService.GetReviewByIdAsync(id);
            if (value == null)
                return NotFound("Review bulunamadi.");
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto dto)
        {
            await _reviewService.CreateReviewAsync(dto);
            return Ok("Review ekleme başarılı.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteReview(string id)
        {
            await _reviewService.DeleteAsync(id);
            return Ok("Silme başarılı.");
        }
    }
}
