namespace StudentGradeReport.Application.CQRS.Student.Commands.UpdateStudent
{
    public class UpdateStudentResponse
    {
        public bool Success { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}
