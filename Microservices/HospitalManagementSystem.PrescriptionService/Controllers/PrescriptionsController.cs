using HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos;
using HospitalManagementSystem.PrescriptionService.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.PrescriptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController(IPrescriptionService prescriptionService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreatePrescription(CreatePrescriptionDto dto)
        {
            if (dto == null)
                return BadRequest("Reçete geçersiz");

            await prescriptionService.CreateAsync(dto);
            return Ok("Reçete oluşturuldu.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await prescriptionService.GetByIdAsync(id);
            if (value == null)
                return NotFound("Reçete bulunamadı");
            return Ok(value);
        }
        [HttpGet("GetByAppointmentId")]
        public async Task<IActionResult> GetByAppointmentId(int id)
        {
            var value = await prescriptionService.GetByAppointmentIdAsync(id);
            if (value == null)
                return NotFound("Reçete bulunamadı");
            return Ok(value);
        }
        [HttpGet("GetByPatientId")]
        public async Task<IActionResult> GetByPatientId(int id)
        {
            var value = await prescriptionService.GetByPatiendIdAsync(id);
            if (value == null)
                return NotFound("Reçete bulunamadı");
            return Ok(value);
        }
    }
}
