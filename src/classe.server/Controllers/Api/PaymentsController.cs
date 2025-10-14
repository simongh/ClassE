using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("")]
        public async Task<IActionResult> QueryAsync([FromQuery] Payments.PaymentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Payments.UpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("Query", new
            {
            }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, Payments.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Id = id,
            });
            return NoContent();
        }
    }
}