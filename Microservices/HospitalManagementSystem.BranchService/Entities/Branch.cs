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
    }
}
