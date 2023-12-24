using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourses
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, GetCoursesQueryResponse>
    {
        private readonly StudentGradeReportContext _context;
        public GetCoursesQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<GetCoursesQueryResponse> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCoursesQueryResponse();
           
            var count = await _context.Courses.CountAsync(cancellationToken);
            var courses = await _context.Courses
                  .Skip((request.PageNumber - 1) * request.PageSize)
                  .Take(request.PageSize)
                 .ToListAsync(cancellationToken);
            response.Total = count;
            response.Courses = courses;
            return response;
        }
    }
}
