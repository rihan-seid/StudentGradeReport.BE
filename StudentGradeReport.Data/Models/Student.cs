using StudentGradeReport.Data.Common;

namespace StudentGradeReport.Data.Entities
{
    public class Student : SharedAttributes
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }

        public ICollection<Grade> AcademicRecord { get; set; } = new List<Grade>();
        public ICollection<Course> Courses { get; set; } = new List<Course>();


    }
}
