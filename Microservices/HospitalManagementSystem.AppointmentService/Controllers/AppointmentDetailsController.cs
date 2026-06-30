using HospitalManagementSystem.AppointmentService.Dtos.AppointmetDetailDtos;
using HospitalManagementSystem.AppointmentService.Services.AppointmentDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentDetailsController(IAppointmentDetailService appointmentDetailService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAppointmentDetail(CreateAppointmentDetailDto dto)
        {
            await appointmentDetailService.CreateAsync(dto);
            return Ok("Randevu detayı başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAppointmentDetail(UpdateAppointmentDetailDto dto)
        {
            await appointmentDetailService.UpdateAsync(dto);
            return Ok("Randevu detayı başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentDetail(int id)
        {
            var value = await appointmentDetailService.GetByAppointmentId(id);
            if (value == null)
                return NotFound("Randevu detayı bulunamadı.");
            return Ok(value);
        }
    }
}
