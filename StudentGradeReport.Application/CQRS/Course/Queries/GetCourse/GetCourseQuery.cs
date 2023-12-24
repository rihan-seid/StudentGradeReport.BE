using MediatR;

namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourse
{
    public class GetCourseQuery: IRequest<GetCourseResponse>
    {
        public  string CourseCode { get; set; }
    }

}
