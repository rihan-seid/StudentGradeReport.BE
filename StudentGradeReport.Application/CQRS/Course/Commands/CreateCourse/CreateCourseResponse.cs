namespace StudentGradeReport.Application.CQRS.Course.Commands.CreateCourse
{
    public class CreateCourseResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
