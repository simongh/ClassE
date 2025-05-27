using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Bookings.UpdateCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, Bookings.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Id = id,
            });
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Bookings.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}