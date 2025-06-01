using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("")]
        public async Task<IActionResult> QueryAsync([FromQuery] Classes.ClassesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Classes.UpdateCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetAsync), result, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] Classes.GetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, Classes.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Id = id,
            });
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Classes.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{classId:int}/sessions")]
        public async Task<IActionResult> SessionsAsync(int classId, [FromQuery] Sessions.SessionsQuery query)
        {
            return Ok(await _mediator.Send(query with
            {
                Class = classId,
            }));
        }

        [HttpPost("{classId:int}/sessions")]
        public async Task<IActionResult> CreateSessionAsync(int classId, Sessions.UpdateCommand command)
        {
            var result = await _mediator.Send(command with
            {
                Class = classId
            });

            return CreatedAtAction(nameof(GetSessionAsync), new
            {
                Class = classId,
                Id = result,
            }, result);
        }

        [HttpGet("{class:int}/sessions/{id:int}")]
        public async Task<IActionResult> GetSessionAsync([FromRoute] Sessions.GetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{classId:int}/sessions/{id:int}")]
        public async Task<IActionResult> UpdateSessionAsync(int classId, int id, Sessions.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Class = classId,
                Id = id
            });
            return NoContent();
        }

        [HttpDelete("{class:int}/sessions/{id:int}")]
        public async Task<IActionResult> DeleteSessionAsync([FromRoute] Sessions.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}