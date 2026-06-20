namespace HospitalManagementSystem.BranchService.Dtos.BranchDtos
{
    public class CreateBranchDto
    {
        public string BranchName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
