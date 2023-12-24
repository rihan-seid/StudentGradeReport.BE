using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentGradeReport.Application.CQRS.Grade.Commands.CreateGrade;
using StudentGradeReport.Application.CQRS.Grade.Commands.DeleteGrade;
using StudentGradeReport.Application.CQRS.Grade.Commands.UpdateGrade;
using StudentGradeReport.Application.CQRS.Grade.Queries.GetGrades;

namespace StudentGradeReport.API.Controllers.Grade
{
    [Route("api/Grade")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GradeController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet("all")]
        public async Task<GetGradesQResponse> GetGrades([FromQuery] GetGradesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpGet()]
        public async Task<GetGradesQResponse> GetGrade([FromQuery] GetGradesQuery query)
        {
            return await _mediator.Send(query);
        }

        [HttpPost()]
        public async Task<CreateGradesResponse> Create(CreateGradeCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut()]
        public async Task<UpdateGradeResponse> Update(UpdateGradeCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete()]
        public async Task<DeleteGradeResponse> Delete(DeleteGradeCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
