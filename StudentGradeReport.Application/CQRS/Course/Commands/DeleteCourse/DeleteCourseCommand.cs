using MediatR;

namespace StudentGradeReport.Application.CQRS.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommand: IRequest<DeleteCourseResponse>
    {
        public required string CourseCode { get; set; }
    }
}
