using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrades
{
    internal sealed class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, GetGradesQResponse>
    {
        private readonly StudentGradeReportContext _context;
        public GetGradesQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<GetGradesQResponse> Handle(GetGradesQuery request, CancellationToken cancellationToken)
        {
            var grades = await _context.Grades.OrderBy(x => x.Id)
                  .Skip((request.PageNumber - 1) * request.PageSize)
                  .Take(request.PageSize)
                .ToListAsync();

            var total = await _context.Grades.CountAsync(cancellationToken);
            return new GetGradesQResponse
            {
                Grades = grades,
                Total = total
            };
        }
    }
}
