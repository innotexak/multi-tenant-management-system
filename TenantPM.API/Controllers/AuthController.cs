
using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TenantPM.Application.Auth.Command.Login;
using TenantPM.Application.Auth.Command.Register;
using TenantPM.Contrast.Request.Auth;
using TenantPM.Contrast.Response.Auth;

namespace TenantPM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("login", Name = "LoginUser")]
        public async Task<LoginResponse> Login([FromBody] LoginRequest request)
        {
            var command = _mapper.Map<LoginCommand>(request);
            var commandResponse =  await _mediator.Send(command);
            return _mapper.Map<LoginResponse>(commandResponse);
        }


        [HttpPost("register", Name = "RegisterUser")]
        public async Task<RegisterationResponse> Register([FromBody] RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            var regCommandResponse =  await _mediator.Send(command);
            return _mapper.Map<RegisterationResponse>(regCommandResponse);
         
        }
    }
}
