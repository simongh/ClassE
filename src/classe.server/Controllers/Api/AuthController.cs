using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClassE.Controllers.Api
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(Login.LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("token")]
        [Authorize(Policy = "cookies")]
        public async Task<IActionResult> TokenAsync()
        {
            var result = await _mediator.Send(new Tokens.GetTokenCommand
            {
                User = (User.Identity as ClaimsIdentity)!
            });

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(StatusCodes.Status403Forbidden);
        }

        [HttpPost("logout")]
        [Authorize(Policy = "cookies")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();

            return NoContent();
        }
    }
}