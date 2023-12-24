using MediatR;

namespace StudentGradeReport.Application.CQRS.Grade.Commands.DeleteGrade
{
    public class DeleteGradeCommand: IRequest<DeleteGradeResponse>
    {
        public Guid Id { get; set; }
    }
}
