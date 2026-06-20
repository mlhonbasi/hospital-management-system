using HospitalManagementSystem.BranchService.Dtos.BranchDtos;
using HospitalManagementSystem.BranchService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.BranchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> BranchList()
        {
            var values = await _branchService.GetAllAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBranch(CreateBranchDto createBranchDto)
        {
            await _branchService.CreateAsync(createBranchDto);
            return Ok("Ekleme basarili!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(string id)
        {
            await _branchService.DeleteAsync(id);
            return Ok("Silme basarili");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
        {
            await _branchService.UpdateAsync(updateBranchDto);
            return Ok("Guncelleme basarili");
        }

        [HttpGet("GetBranch")]
        public async Task<IActionResult> GetBranch(string id)
        {
            var value = await _branchService.GetByIdAsync(id);
            return Ok(value);
        }
    }
}
