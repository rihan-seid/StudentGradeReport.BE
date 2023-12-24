namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourse
{
    public class GetCourseResponse
    {
        public string? ErrorMessage { get;  set; }
        public bool Success { get;  set; }
        public Data.Entities.Course Course { get;  set; }
    }

}
