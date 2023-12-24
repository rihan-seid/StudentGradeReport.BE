using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudents
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, GetStudentsResponse>
    {
        private readonly StudentGradeReportContext _context;
        public GetStudentsQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<GetStudentsResponse> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Students.OrderBy(st => st.Id)
                .Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                .ToListAsync(cancellationToken);

            var count = await _context.Students.CountAsync(cancellationToken);

            return new GetStudentsResponse
            {
                Total = count,
                Students = students
            };
        }
    }
}
