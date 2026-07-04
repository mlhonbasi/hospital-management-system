namespace HospitalManagementSystem.PrescriptionService.Entities
{
    public class PrescriptionItem
    {
        public int PrescriptionItemId { get; set; }
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public string MedicineName { get; set; }
        public string Usage { get; set; }
        public string Duration { get; set; }

    }
}
