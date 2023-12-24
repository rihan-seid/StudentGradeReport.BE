using MediatR;


namespace StudentGradeReport.Application.CQRS.Grade.Commands.CreateGrade
{
    public class CreateGradeCommand : IRequest<CreateGradesResponse>
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string CourseCode { get; set; }
        public int GradeValue { get; set; }
        public DateTime Date { get; set; }
        public string LetterGrade { get; set; }
    }
}
