using MediatR;

namespace StudentGradeReport.Application.CQRS.Course.Commands.CreateCourse
{
    public class CreateCourseCommand : IRequest<CreateCourseResponse>
    {
        public required string Title { get; set; }
        public required string CourseCode { get; set; }
        public int CreditHours { get; set; }
        public string? Description { get; set; }
    }
}
