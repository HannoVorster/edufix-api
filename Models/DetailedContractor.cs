namespace EduFix_Api.Models
{
    public class DetailedContractor
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? UserCreated { get; set; }
        public string? Department { get; set; }
        public string? LocationRoom { get; set; }
        public string? Facility { get; set; }
        public string? Discipline { get; set; }
        public string? NewComment { get; set; }
        public string? Status { get; set; }
        public string? ResponseTime { get; set; }
        public string? EmergencyNormal { get; set; }
        public string? AssessComment { get; set; }
        public string? ApproveMandate { get; set; }
        public string? ApproveComment { get; set; }
        public string? ApproveUser { get; set; }
    }
}