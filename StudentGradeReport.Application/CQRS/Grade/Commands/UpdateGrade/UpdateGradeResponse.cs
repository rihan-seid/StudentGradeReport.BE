namespace StudentGradeReport.Application.CQRS.Grade.Commands.UpdateGrade
{
    public class UpdateGradeResponse
    {
        public bool Success { get; internal set; }
        public string ErrorMessage { get; internal set; }
    }
}
