using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<UpdateStudentResponse>
    {
        public Guid Id { get;  set; }
        public Data.Entities.Student Student { get; set; }
    }


}
