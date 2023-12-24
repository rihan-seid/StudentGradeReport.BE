using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Queries
{
    public class PassFailSummaryQuery: IRequest<PassFailSummaryResponse>
    {
    }
}
