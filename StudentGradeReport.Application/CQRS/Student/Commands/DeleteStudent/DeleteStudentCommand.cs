using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<DeleteStudentResponse>
    {
        public Guid Id { get; internal set; }
    }
}
