using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "token")]
    public class SessionsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("{id:int}/attendees")]
        public async Task<IActionResult> AttendeesAsync(int id, Attendees.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Session = id
            });
            return NoContent();
        }
    }
}