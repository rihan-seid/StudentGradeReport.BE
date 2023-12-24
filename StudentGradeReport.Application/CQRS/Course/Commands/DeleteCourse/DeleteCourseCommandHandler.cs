using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Course.Commands.DeleteCourse
{
    internal sealed class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeleteCourseResponse>
    {
        private readonly StudentGradeReportContext _context;
        public DeleteCourseCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<DeleteCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteCourseResponse()
            {
                Success = false
            };

            var course = await _context.Courses.Where(c => c.CourseCode == request.CourseCode).FirstOrDefaultAsync(cancellationToken);

            if (course == null)
            {
                response.ErrorMessage = "Unable to find a course with a given course code";
                return response;
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync(cancellationToken);
            response.Success = true;
            return response;
        }
    }
}
