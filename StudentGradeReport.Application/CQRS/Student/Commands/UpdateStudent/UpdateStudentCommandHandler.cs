using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Commands.UpdateStudent
{
    internal sealed class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentResponse>
    {
        private readonly StudentGradeReportContext _context;
        public UpdateStudentCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<UpdateStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateStudentResponse()
            {
                Success = false,
                ErrorMessage = ""
            };

            var student= await _context.Students.FindAsync(request.Id, cancellationToken);
            if(student is null)
            {
                response.ErrorMessage = "Unable to find a student with a given id";
                return response;
            }

            student.Address = request.Student.Address;
            student.PhoneNumber = request.Student.PhoneNumber;
            student.Name = request.Student.Name;

            _context.Students.Update(student);
            await _context.SaveChangesAsync(cancellationToken);
            response.Success = true;
            return response;
        }
    }
}
