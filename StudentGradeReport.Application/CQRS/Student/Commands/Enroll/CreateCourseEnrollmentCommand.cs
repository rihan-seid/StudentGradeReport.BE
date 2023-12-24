using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;
using StudentGradeReport.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeReport.Application.CQRS.Student.Commands.Enroll
{
    public class CreateCourseEnrollmentCommand : IRequest<CourseEnrollmentResponse>
    {
        public required string CourseCode { get; set; }
        public Guid StudentId { get; set; }
        public Semisters Semester { get; set; }

    }
    public class CourseEnrollmentResponse
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CreateCourseEnrollmentCommandHandler : IRequestHandler<CreateCourseEnrollmentCommand, CourseEnrollmentResponse>
    {

        private readonly StudentGradeReportContext _context;
        public CreateCourseEnrollmentCommandHandler(StudentGradeReportContext context)
        {
            _context = context;
        }
        public async Task<CourseEnrollmentResponse> Handle(CreateCourseEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var response = new CourseEnrollmentResponse()
            {
                Success = false,
                ErrorMessage = ""
            };


            //check if course id is valid 
            var course= await _context.Courses.Where(c=>c.CourseCode==request.CourseCode).AnyAsync(cancellationToken);
            if(!course)
            {
                response.Success = false;
                response.ErrorMessage = "Invalid course code";
                return response;
            }

            // check if student id is valid 

            var student = await _context.Students.Where(s => s.Id == request.StudentId).AnyAsync(cancellationToken);
            if (!student)
            {
                response.Success = false;
                response.ErrorMessage = "Invalid student id";
                return response;
            }

            //check if already enrolled 
            var enrolled= await _context.Enrollments.Where(e => e.StudentId == request.StudentId && e.CourseCode == request.CourseCode).AnyAsync(cancellationToken);
            if (enrolled)
            {
                response.Success = false;
                response.ErrorMessage= "Student already enrolled for the course";
                return response;
            }

            var enrollment = new CourseEnrollment
            {
                CourseCode = request.CourseCode,
                StudentId = request.StudentId,
                Semester = request.Semester,
                CreatedAt = DateTime.Now,
                CreatedBy = "admin"
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync(cancellationToken);
            response.Success = true;
            return response;            

        }
    }

}
