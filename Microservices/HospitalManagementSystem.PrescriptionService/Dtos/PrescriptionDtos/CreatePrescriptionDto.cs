namespace HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos
{
    public class CreatePrescriptionDto
    {
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }
}
