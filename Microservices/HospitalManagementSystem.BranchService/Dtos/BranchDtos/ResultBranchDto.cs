namespace HospitalManagementSystem.BranchService.Dtos.BranchDtos
{
    public class ResultBranchDto
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
