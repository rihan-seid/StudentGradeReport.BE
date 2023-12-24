namespace StudentGradeReport.Application.CQRS.Grade.Commands.CreateGrade
{
    public class CreateGradesResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }

    }
}
