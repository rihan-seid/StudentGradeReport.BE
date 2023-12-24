namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrade
{
    public class GetGradeResponse
    {
        public bool Success { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public Data.Entities.Grade Grade { get; internal set; }
    }


}
