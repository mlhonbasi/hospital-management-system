namespace HospitalManagementSystem.PrescriptionService.Dtos.PrescriptionDtos
{
    public class ResultPrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }
}
