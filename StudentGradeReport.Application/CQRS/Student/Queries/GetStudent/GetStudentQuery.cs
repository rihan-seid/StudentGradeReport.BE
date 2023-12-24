using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudent
{
    public class GetStudentQuery: IRequest<GetStudentQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
