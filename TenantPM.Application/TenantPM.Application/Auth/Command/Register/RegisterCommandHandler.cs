using AutoMapper;
using MediatR;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;
using TenantPM.Domain.Enums;

namespace TenantPM.Application.Auth.Command.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;

        public RegisterCommandHandler(IMapper mapper, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<RegisterCommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
           
            var validator = new RegisterCommandValidator(_userRepository);
            var validationResult =await  validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
            {
                return new RegisterCommandResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var user = _mapper.Map<User>(request);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.Role = RoleEnum.Member;

            await _userRepository.AddAsync(user);

            return new RegisterCommandResponse
            {
                Success = true,
                Message = "Registration completed successfully.",
                Data=user.Id,
            };

        }
    }
}
