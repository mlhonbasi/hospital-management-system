using HospitalManagementSystem.AppointmentService.Entitites;

namespace HospitalManagementSystem.AppointmentService.Dtos.AppointmentDtos
{
    public class GetAppointmentByIdDto
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
    }
}
