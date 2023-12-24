using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudents
{
    public class GetStudentsQuery : IRequest<GetStudentsResponse>
    {

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
