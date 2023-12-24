namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourses
{
    public class GetCoursesQueryResponse
    {
        public int Total { get; set; }
        public List<Data.Entities.Course> Courses { get; set; }
    }
}
