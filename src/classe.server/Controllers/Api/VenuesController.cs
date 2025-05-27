using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenuesController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("")]
        public async Task<IActionResult> QueryAsync([FromQuery] Venue.VenueQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Venue.UpdateVenueCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAsync), result, null);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] Venue.GetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, Venue.UpdateVenueCommand command)
        {
            await _mediator.Send(command with
            {
                Id = id
            });
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Venue.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}