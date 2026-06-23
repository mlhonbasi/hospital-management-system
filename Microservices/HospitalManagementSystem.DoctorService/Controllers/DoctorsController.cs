using HospitalManagementSystem.DoctorService.Dtos.DoctorDtos;
using HospitalManagementSystem.DoctorService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.DoctorService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController(IDoctorService _doctorService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync(); 
            return Ok(doctors);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto dto)
        {
            await _doctorService.CreateAsync(dto);
            return Ok("Doktor başarıyla oluşturuldu.");
        }
        [HttpGet("GetDoctor")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            return Ok(doctor);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok("Silme başarılı.");
        }
    }
}
