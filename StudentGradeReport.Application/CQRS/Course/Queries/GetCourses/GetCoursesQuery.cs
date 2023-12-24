using MediatR;

namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourses
{
    public class GetCoursesQuery : IRequest<GetCoursesQueryResponse>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

    }
}
