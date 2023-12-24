using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data.Entities;
using StudentGradeReport.Data.Models;
using System.Net;

namespace StudentGradeReport.Data
{
    public class StudentGradeReportContext: DbContext

    {
        public StudentGradeReportContext(DbContextOptions<StudentGradeReportContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure CourseCode is unique
            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            // Configure the foreign key relationship
            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course) // Grade has one Course
                .WithMany(c => c.Grades) // Course has many Grades
                .HasForeignKey(g => g.CourseCode) // The foreign key is CourseCode
                .HasPrincipalKey(c => c.CourseCode); // The principal key in Course is CourseCode
        
        modelBuilder.Entity<Student>().HasData( 
                new Student
                {
                    Id =Guid.NewGuid(),
                    Name = "Rihana Seid",
                    Email = "rehana@gmail.com",
                    Address = "Addis Ababa",
                    CreatedBy = "Admin",
                    PhoneNumber= "098327487238",
                    CreatedAt = DateTime.Now,
                    
                },
                new Student {
                    Id = Guid.NewGuid(),
                    Name = "Habiba Seid",
                    Email = "habibaseid@gmail.com",
                    Address = "Addis Ababa",
                    CreatedBy = "Admin",
                    PhoneNumber = "09832748723",
                    CreatedAt = DateTime.Now,
            });
        }   

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<CourseEnrollment> Enrollments { get; set; } = null!;

    }
}
