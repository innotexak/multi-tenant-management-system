
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TenantPM.Application.Auth.Command.Login;
using TenantPM.Application.Auth.Command.Register;

namespace TenantPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login", Name = "LoginUser")]
        public async Task<LoginCommandResponse> Login([FromBody] LoginCommand loginCommand)
        {
            return await _mediator.Send(loginCommand);
        }


        [HttpPost("register", Name = "RegisterUser")]
        public async Task<RegisterCommandResponse> Register([FromBody] RegisterCommand registerCommand)
        {
            return await _mediator.Send(registerCommand);
        }
    }
}
