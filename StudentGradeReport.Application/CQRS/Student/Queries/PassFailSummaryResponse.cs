namespace StudentGradeReport.Application.CQRS.Student.Queries
{
    public class PassFailSummaryResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public List<CourseGradeSummary> CourseGradeSummaries { get; set; }
    }
}
