namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudent
{
    public class GetStudentQueryResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public Data.Entities.Student Stduent { get; internal set; }
    }
}
