using MediatR;

namespace StudentGradeReport.Application.CQRS.Grade.Commands.UpdateGrade
{
    public class UpdateGradeCommand: IRequest<UpdateGradeResponse>
    {
      public Data.Entities.Grade Grade { get; set; }
     public Guid Id { get; set; }
    }
}
