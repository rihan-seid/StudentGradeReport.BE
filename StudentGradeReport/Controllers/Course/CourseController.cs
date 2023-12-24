using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentGradeReport.Application.CQRS.Course.Commands.CreateCourse;
using StudentGradeReport.Application.CQRS.Course.Commands.DeleteCourse;
using StudentGradeReport.Application.CQRS.Course.Commands.UpdateCourse;
using StudentGradeReport.Application.CQRS.Course.Queries.GetCourse;
using StudentGradeReport.Application.CQRS.Course.Queries.GetCourses;

namespace StudentGradeReport.API.Controllers.Course
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<GetCoursesQueryResponse> GetAll([FromQuery] GetCoursesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet("getById")]
        public async Task<GetCourseResponse> Get([FromQuery] GetCourseQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost("create")]
        public async Task<CreateCourseResponse> Create([FromBody] CreateCourseCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("update")]
        public async Task<UpdateCourseResponse> Update([FromBody] UpdateCourseCommand command)
        {
            return await _mediator.Send(command);
        }


        [HttpDelete("delete")]
        public async Task<DeleteCourseResponse> Delete([FromBody] DeleteCourseCommand command)
        {
            return await _mediator.Send(command);
        }


    }
}
