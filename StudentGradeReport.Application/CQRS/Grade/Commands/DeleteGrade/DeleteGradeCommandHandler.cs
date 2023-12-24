using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Grade.Commands.DeleteGrade
{
    internal sealed class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand, DeleteGradeResponse>
    {

        private readonly StudentGradeReportContext _context;
        public DeleteGradeCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<DeleteGradeResponse> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteGradeResponse();
           
            var grade = await _context.Grades.FindAsync(request.Id);
            if (grade == null)
            {
                response.ErrorMessage = "Unable to find a grade with a given id";
                response.Success = false;
                return response;
            }
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync(cancellationToken);
            response.Success = true;
            return response;
        }
    }
}
