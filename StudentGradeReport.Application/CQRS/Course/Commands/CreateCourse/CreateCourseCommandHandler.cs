using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Course.Commands.CreateCourse
{
    internal sealed class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseResponse>
    {
        private readonly StudentGradeReportContext _studentGradeReportContext;
        public CreateCourseCommandHandler(StudentGradeReportContext gradeReportContext)
        {
            _studentGradeReportContext = gradeReportContext;
        }
        public async Task<CreateCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCourseResponse()
            {
                Success = false,
                ErrorMessage = string.Empty
            };

            if(string.IsNullOrEmpty(request.Title))
            {
                response.ErrorMessage = "Title is required";
                return response;
            }

            if(string.IsNullOrEmpty(request.CourseCode))
            {
                response.ErrorMessage = "Course Code is required";
                return response;
            }


            if(request.CreditHours <= 0 || request.CreditHours>5)
            {
                response.ErrorMessage = "Credit Hours must be greater than 0 and less than 5";
                return response;
            }

            if(_studentGradeReportContext.Courses.Any(x=>x.Title == request.Title|| x.CourseCode==request.CourseCode))
            {
                response.ErrorMessage = "Course already exists";
                return response;
            }
            var course = new Data.Entities.Course()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                CreditHours = request.CreditHours,
                CourseCode = request.CourseCode,
                CreatedBy = "admin",
                Description = request.Description
            };
            _studentGradeReportContext.Courses.Add(course);
            await _studentGradeReportContext.SaveChangesAsync(cancellationToken);
            response.Success = true;
            response.Id = course.Id;
            return response;
        }
    }
}
