using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Course.Queries.GetCourse
{
    internal sealed class GetCourseQueryHandler : IRequestHandler<GetCourseQuery, GetCourseResponse>
    {
        private readonly StudentGradeReportContext _context;

        public GetCourseQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }

       
        public async Task<GetCourseResponse> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            var response = new GetCourseResponse();
            if (request.CourseCode == null)
            {
                response.ErrorMessage = "Course code cannot be null";
                response.Success = false;
                return response;
            }
            var course = await _context.Courses.Where(c=>c.CourseCode== request.CourseCode).FirstOrDefaultAsync(cancellationToken);  
            if (course == null)
            {
                response.ErrorMessage = "Unable to find a course with a given course code";
                response.Success = false;
                return response;
            }
            response.Course = course;
            response.Success = true;
            return response;
        }
    }

}
