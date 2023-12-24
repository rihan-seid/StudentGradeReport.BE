using StudentGradeReport.Data.Common;

namespace StudentGradeReport.Data.Entities
{
    public class Course: SharedAttributes
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required double CreditHours { get; set; }

        public ICollection<Student> Students { get; set; }= new List<Student>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();




    }

}
