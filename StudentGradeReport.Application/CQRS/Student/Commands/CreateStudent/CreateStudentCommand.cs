using MediatR;

namespace StudentGradeReport.Application.CQRS.Student.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<CreateStudentResponse>
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
    }



}
