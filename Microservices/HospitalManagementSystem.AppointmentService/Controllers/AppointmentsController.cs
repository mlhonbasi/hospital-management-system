using HospitalManagementSystem.AppointmentService.Dtos.AppointmentDtos;
using HospitalManagementSystem.AppointmentService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController(IAppointmentService _appointmentService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto dto)
        {
            await _appointmentService.CreateAsync(dto);
            return Ok("Randevu olusturuldu");
        }
        [HttpGet]
        public async Task<IActionResult> AppointmentList()
        {
            var values = await _appointmentService.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var value = await _appointmentService.GetByIdAsync(id);
            if (value == null)
                return NotFound("Randevu bulunamadı.");
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto dto)
        {
            await _appointmentService.UpdateAsync(dto);
            return Ok("Randevu başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAsync(id);
            return Ok("Randevu başarıyla silindi.");
        }
    }
}
