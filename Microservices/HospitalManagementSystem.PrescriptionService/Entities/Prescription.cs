namespace HospitalManagementSystem.PrescriptionService.Entities
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
