using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Student.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentResponse>
    {
        private readonly StudentGradeReportContext __context;
        public CreateStudentCommandHandler(StudentGradeReportContext context)
        {
            __context = context;
        }
        public async Task<CreateStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStudentResponse();
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                response.Success = false;
                response.ErrorMessage = "Student Name is required";
                return response;
            }
            var student = new Data.Entities.Student()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                CreatedBy = "admin",
                CreatedAt = DateTime.Now,
            };

            var studentExists = await __context.Students.AnyAsync(x => x.Name == request.Name, cancellationToken);
            if (studentExists)
            {
                response.Success = false;
                response.ErrorMessage = "Student already exists";
                return response;
            }
            __context.Students.Add(student);
            await __context.SaveChangesAsync(cancellationToken);
            response.Id = student.Id;
            response.Success = true;
            return response;
        }
    }

}
