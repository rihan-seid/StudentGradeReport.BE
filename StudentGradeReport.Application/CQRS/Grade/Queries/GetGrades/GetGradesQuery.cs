using MediatR;


namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrades
{
    public class GetGradesQuery : IRequest<GetGradesQResponse>
    {


        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
