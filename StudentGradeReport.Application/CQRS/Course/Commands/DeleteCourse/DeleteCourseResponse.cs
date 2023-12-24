namespace StudentGradeReport.Application.CQRS.Course.Commands.DeleteCourse
{
    public class DeleteCourseResponse
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; internal set; }
    }
}
