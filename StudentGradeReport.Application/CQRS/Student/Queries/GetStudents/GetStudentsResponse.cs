namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudents
{
    public class GetStudentsResponse
    {
        public int Total { get; set; }
        public List<Data.Entities.Student> Students { get; set; }
    }
}
