namespace StudentGradeReport.Application.CQRS.Student.Commands.CreateStudent
{
    public class CreateStudentResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }
    }

}
