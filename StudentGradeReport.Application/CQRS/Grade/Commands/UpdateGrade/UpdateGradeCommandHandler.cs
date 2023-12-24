using MediatR;
using StudentGradeReport.Data;

namespace StudentGradeReport.Application.CQRS.Grade.Commands.UpdateGrade
{
    internal sealed class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, UpdateGradeResponse>
    {
        private readonly StudentGradeReportContext _context;

        public UpdateGradeCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<UpdateGradeResponse> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
           var response= new UpdateGradeResponse();

            var Grade= await _context.Grades.FindAsync(request.Id,cancellationToken);
            if (Grade == null)
            {
                response.Success = false;
                response.ErrorMessage = "Unable to find a grade";
                return response;
            }

            Grade.StudentId = request.Grade.StudentId;
            Grade.CourseCode = request.Grade.CourseCode; //Todo change this to course code and add missing attributes
           
            _context.Grades.Update(Grade);
            await _context.SaveChangesAsync(cancellationToken);

            return response;
           
        }
    }
}
