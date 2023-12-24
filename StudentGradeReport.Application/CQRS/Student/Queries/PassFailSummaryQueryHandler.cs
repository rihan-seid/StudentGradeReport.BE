using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Queries
{
    internal sealed class PassFailSummaryQueryHandler : IRequestHandler<PassFailSummaryQuery, PassFailSummaryResponse>
    {

        private readonly StudentGradeReportContext _context;
        public PassFailSummaryQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<PassFailSummaryResponse> Handle(PassFailSummaryQuery request, CancellationToken cancellationToken)
        {
            var response = new PassFailSummaryResponse();
            var courseGradeSummaries = await _context.Grades
                    .Include(g => g.Course) 
        .GroupBy(g => g.CourseCode)
        .Select(group => new CourseGradeSummary
        {
            CourseCode = group.Key,
            CourseName= group.First().Course.Title,  
            PassCount = group.Count(g => g.LetterGradeEnum == LetterGrades.A || g.LetterGradeEnum == LetterGrades.B || g.LetterGradeEnum == LetterGrades.C),
            FailCount = group.Count(g => g.LetterGradeEnum ==LetterGrades.D || g.LetterGradeEnum == LetterGrades.F)
        })
        .ToListAsync(cancellationToken);

            response.CourseGradeSummaries= courseGradeSummaries;
            response.Success = true;

            return response;
        }
    }
}
