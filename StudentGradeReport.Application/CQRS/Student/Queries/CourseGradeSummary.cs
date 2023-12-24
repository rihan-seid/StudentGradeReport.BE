namespace StudentGradeReport.Application.CQRS.Student.Queries
{
    public class CourseGradeSummary
    {
        public required string CourseCode { get; set; }
        public required string CourseName { get; set; }
        public int PassCount { get; set; }
        public int FailCount { get; set; }
    }
}
