namespace StudentGradeReport.Data.Common
{
    public class SharedAttributes
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;

        public required string CreatedBy { get; set; } 
        public string? UpdatedBy { get; set; } = null;

    }
}
