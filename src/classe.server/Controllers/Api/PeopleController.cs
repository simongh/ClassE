using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassE.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("")]
        public async Task<IActionResult> QueryAsync([FromQuery] Person.PersonQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListAsync()
        {
            return Ok(await _mediator.Send(new Person.ListQuery()));
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(Person.UpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status100Continue, result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync([FromRoute] Person.GetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, Person.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Id = id,
            });
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Person.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{person:int}/payments")]
        public async Task<IActionResult> PaymentsAsync([FromRoute] Payments.PaymentsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("{person:int}/payments")]
        public async Task<IActionResult> CreatePaymentAsync(int person, Payments.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Person = person,
            });

            return Created();
        }

        [HttpPut("{person:int}/payments/{payment:int}")]
        public async Task<IActionResult> UpdatePaymentAsync(int person, int payment, Payments.UpdateCommand command)
        {
            await _mediator.Send(command with
            {
                Person = person,
                Id = payment,
            });
            return NoContent();
        }

        [HttpDelete("{person:int}/payments/{id:int}")]
        public async Task<IActionResult> DeletePaymentAsync([FromRoute] Payments.DeleteCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id:int}/sessions")]
        public async Task<IActionResult> SessionsQueryAsync(int id, [FromQuery] Sessions.SessionsQuery query)
        {
            return Ok(await _mediator.Send(query with
            {
                Person = id
            }));
        }
    }
}