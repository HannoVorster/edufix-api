namespace EduFix_Api.Models
{
    public class RequestList
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Discipline { get; set; }
        public string? Status { get; set; }
    }
}