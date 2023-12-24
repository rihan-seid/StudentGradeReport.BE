using StudentGradeReport.Data.Common;

namespace StudentGradeReport.Data.Models
{
    public class CourseEnrollment: SharedAttributes
    {
        public Guid Id { get; set; }
        public required string CourseCode { get; set; }
        public Guid StudentId { get; set; }
        public required Semisters Semester { get; set; }
    }
}
