using StudentGradeReport.Data.Common;

namespace StudentGradeReport.Data.Entities
{
    public class Grade: SharedAttributes
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public Guid StudentId { get; set; }
        public int Score { get; set; }
        public LetterGrades LetterGradeEnum { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
       
    }

}
