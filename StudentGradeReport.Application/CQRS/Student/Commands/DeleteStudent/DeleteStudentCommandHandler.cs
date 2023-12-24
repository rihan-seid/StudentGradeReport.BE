using Azure;
using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeleteStudentResponse>
    {

        private readonly StudentGradeReportContext _context;
        public DeleteStudentCommandHandler(StudentGradeReportContext context)
        {

            _context = context;
        }
        public async Task<DeleteStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var response= new DeleteStudentResponse();

            var student =await _context.Students.FindAsync(request.Id);
            if (student == null)
            {
                response.ErrorMessage = "Unable to find a student with a given id";
                response.Success = false;
                return response;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
            response.Success = true;
            return response;
        }
    }
}
