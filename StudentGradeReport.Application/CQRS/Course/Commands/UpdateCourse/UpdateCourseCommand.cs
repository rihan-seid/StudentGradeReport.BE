using MediatR;

namespace StudentGradeReport.Application.CQRS.Course.Commands.UpdateCourse
{
    public class UpdateCourseCommand: IRequest<UpdateCourseResponse>
    {

        public Data.Entities.Course Course { get; set; }
        public Guid CourseCode { get; set; }
        
    }

}
