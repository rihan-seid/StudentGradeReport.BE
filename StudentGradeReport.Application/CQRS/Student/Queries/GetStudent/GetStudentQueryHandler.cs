using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Queries.GetStudent
{
    internal sealed class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, GetStudentQueryResponse>
    {
        private readonly StudentGradeReportContext _context;
        public GetStudentQueryHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<GetStudentQueryResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
           var response= new GetStudentQueryResponse();
            var student =await _context.Students.FindAsync(request.Id);
            if(student is null)
            {
                response.Success = false;
                response.ErrorMessage = "Unable to find a student with the given Id";
                return response;
            }
            response.Success = true;
            response.Stduent = student;
            return response;
        }
    }
}
