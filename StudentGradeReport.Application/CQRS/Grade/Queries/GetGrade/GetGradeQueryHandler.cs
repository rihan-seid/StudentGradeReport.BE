using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Grade.Queries.GetGrade
{
    internal sealed class GetGradeQueryHandler : IRequestHandler<GetGradeQuery, GetGradeResponse>
    {
        private readonly StudentGradeReportContext _context;
        public GetGradeQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<GetGradeResponse> Handle(GetGradeQuery request, CancellationToken cancellationToken)
        {
            var response = new GetGradeResponse()
            {
                Success = false,
                ErrorMessage = ""
            };

            var Grade = await _context.Grades.FindAsync(request.Id, cancellationToken);
            if (Grade == null)
            {
                response.ErrorMessage = "Unable to find a grade with a given id";
                return response;
            }
            response.Success = true;
            response.Grade = Grade;
            return response;

        }
    }


}
