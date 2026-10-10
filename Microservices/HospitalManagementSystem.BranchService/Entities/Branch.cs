using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HospitalManagementSystem.BranchService.Entities
{
    public class Branch
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public string BranchCode { get; set; }
        public int DoctorCount { get; set; }
        public int MonthlyAppointmentCount { get; set; }
        public int BedCount { get; set; }
        public decimal Rating { get; set; }
        public int OccupancyRate { get; set; }
        public string ThemeColor { get; set; }
    }
}
