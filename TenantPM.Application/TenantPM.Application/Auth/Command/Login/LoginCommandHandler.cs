using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.Auth.DTOs;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.Users.DTOs;
using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.Auth.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IMapper mapper, IJwtTokenService jwtTokenService, IAsyncRepository<User> userRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new LoginCommandResponse
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var user = (await _userRepository.FindAsync(u => u.Email == request.Email, cancellationToken))
              .FirstOrDefault();

            if (user == null)
            {
                return new LoginCommandResponse
                {
                    Success = false,
                    Message = "Invalid credentials."
                };
            }

            var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!passwordValid)
            {
                return new LoginCommandResponse
                {
                    Success = false,
                    Message = "Invalid credentials."
                };
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };


            var accessToken = _jwtTokenService.GenerateAccessToken(claims);
            var refreshToken = _jwtTokenService.GenerateRefreshToken();
            int jwtExpiryTime = ConfigurationBinder.GetValue<int>(_configuration, "Jwt:ExpiryTimeInMinutes");

            var loginResult = new LoginResultDto
            {
                Tokens = new AuthTokenDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(jwtExpiryTime)
                },
                User = _mapper.Map<UserDto>(user)
            };

            return new LoginCommandResponse
            {
                Success = true,
                Message = "Login successful.",
                Data = loginResult
            };
        }
    }
}
