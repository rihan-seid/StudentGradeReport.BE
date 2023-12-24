namespace StudentGradeReport.Application.CQRS.Grade.Commands.DeleteGrade
{
    public class DeleteGradeResponse
    {
        public string ErrorMessage { get; internal set; }
        public bool Success { get; internal set; }
    }
}
