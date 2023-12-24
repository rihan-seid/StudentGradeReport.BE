using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentGradeReport.Application.CQRS.Student.Commands.CreateStudent;
using StudentGradeReport.Application.CQRS.Student.Commands.DeleteStudent;
using StudentGradeReport.Application.CQRS.Student.Commands.Enroll;
using StudentGradeReport.Application.CQRS.Student.Commands.UpdateStudent;
using StudentGradeReport.Application.CQRS.Student.Queries;
using StudentGradeReport.Application.CQRS.Student.Queries.GetStudent;
using StudentGradeReport.Application.CQRS.Student.Queries.GetStudents;

namespace StudentGradeReport.API.Controllers.Student
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<GetStudentsResponse> GetAll([FromQuery] GetStudentsQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("getById")]
        public async Task<GetStudentQueryResponse> Get([FromQuery] GetStudentQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<CreateStudentResponse> Create(CreateStudentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("enroll")]
        public async Task<CourseEnrollmentResponse> Enroll(CreateCourseEnrollmentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("update")]
        public async Task<UpdateStudentResponse> Update(UpdateStudentCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete("delete")]
        public async Task<DeleteStudentResponse> Delete(DeleteStudentCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("passfailSummary")]
        public async Task<PassFailSummaryResponse> Summary()
        {
            return await _mediator.Send(new PassFailSummaryQuery());
        }
    }
}

