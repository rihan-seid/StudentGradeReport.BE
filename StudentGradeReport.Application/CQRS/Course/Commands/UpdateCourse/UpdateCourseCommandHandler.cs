using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Course.Commands.UpdateCourse
{
    internal sealed class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdateCourseResponse>
    {
        private readonly StudentGradeReportContext _context;

        public UpdateCourseCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }

        public async Task<UpdateCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            UpdateCourseResponse response = new() { Success = false, ErrorMessage = string.Empty };

            try
            {
                var course = await _context.Courses.FindAsync(request.CourseCode,cancellationToken);

                if (course == null)
                {
                    response.ErrorMessage = "Course not found";
                    return response;
                }

                course.CourseCode = request.Course.CourseCode;
                course.Title = request.Course.Title;
                course.Description = request.Course.Description;
                course.CreditHours = request.Course.CreditHours;
                _context.Courses.Update(course);
                await _context.SaveChangesAsync(cancellationToken);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }       

            return response;
        }
    }   

}
