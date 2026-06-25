namespace HospitalManagementSystem.AppointmentService.Entitites
{
    public class AppointmentDetail
    {
        public int AppointmentDetailId { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public string Complaint { get; set; }
        public string Notes { get; set; }

        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        
        public bool IsFirstVist { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
