namespace EduFix_Api.Models
{
    public class NewRequest
    {
        public DateTime DateCreated { get; set; }
        public string? UserCreated { get; set; }
        public string? Department { get; set; }
        public string? LocationRoom { get; set; }
        public string? Facility { get; set; }
        public string? Discipline { get; set; }
        public string? NewComment { get; set; }
        public DateTime LastUpdated { get; set; }
        public string? UserLastUpdated { get; set; }
        public string? Status { get; set; }
    }
}