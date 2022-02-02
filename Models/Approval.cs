namespace EduFix_Api.Models
{
    public class Approval
    {
        public int Id { get; set; }
        public string? ApproveMandate { get; set; }
        public string? Comment { get; set; }
        public string? User { get; set; }
    }
}