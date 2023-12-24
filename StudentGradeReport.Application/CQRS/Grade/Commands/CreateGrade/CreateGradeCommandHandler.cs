using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentGradeReport.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradeReport.Application.CQRS.Grade.Commands.CreateGrade
{
    internal sealed class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, CreateGradesResponse>
    {
        private readonly StudentGradeReportContext _context;
        public CreateGradeCommandHandler(StudentGradeReportContext context)
        {
            _context = context;

        }


        public static LetterGrades? MapStringToLetterGrade(string grade)
        {
            if (string.IsNullOrWhiteSpace(grade))
            {
                return null;
            }

            // TryParse with ignoreCase set to true
            if (Enum.TryParse<LetterGrades>(grade, ignoreCase: true, out var letterGrade))
            {
                return letterGrade;
            }

            return null; // Or handle invalid grades as needed
        }


        public async Task<CreateGradesResponse> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateGradesResponse();
            var grade = new Data.Entities.Grade
            {
                Id = request.Id,
                StudentId = request.StudentId,
                CourseCode = request.CourseCode,
                Score = request.GradeValue,
                LetterGradeEnum= MapStringToLetterGrade(request.LetterGrade.ToString())??LetterGrades.F,
                CreatedAt = DateTime.Now,
                CreatedBy = "admin"

            };
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == request.StudentId);
            if (student == null)
            {
                response.Success = false;
                response.ErrorMessage = "Student does not exist";
                return response;
            }


            //check course 

            var course = await _context.Courses.Where(x => x.CourseCode == request.CourseCode).AnyAsync(cancellationToken);
            if (!course)
            {
                response.Success = false;
                response.ErrorMessage = "Invalid course code";
                return response;
            }


           var isEnrolled = await _context.Enrollments.Where(s => s.StudentId == request.StudentId && s.CourseCode == request.CourseCode).AnyAsync(cancellationToken);
            if (!isEnrolled)
            {
                response.Success = false;
                response.ErrorMessage = "Student is not enrolled for the course";
                return response;
            }

            var gradeExists = await _context.Grades.Where(x => x.StudentId == request.StudentId && x.CourseCode == request.CourseCode).AnyAsync(cancellationToken);
            if (gradeExists)
            {
                response.Success = false;
                response.ErrorMessage = "Grade already exists";
                return response;
            }

            _context.Grades.Add(grade);
            _context.SaveChanges();
            response.Id = grade.Id;
            response.Success = true;
            return response;
        }

    }


}
