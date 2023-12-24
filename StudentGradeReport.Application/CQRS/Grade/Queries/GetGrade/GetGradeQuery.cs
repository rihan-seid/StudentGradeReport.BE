using MediatR;

namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrade
{
    public class GetGradeQuery: IRequest<GetGradeResponse>
    {
        public Guid Id { get; set; }
    }
}
