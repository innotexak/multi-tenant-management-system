using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.Projects.Command;
using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.CreateProjectCommand
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateProjectCommandHandler(IMapper mapper, IAsyncRepository<Project> projectRepository, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }
        public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentUserService.UserId
                ?? throw new UnauthorizedAccessException("User not authenticated.");

            var validator = new CreateProjectCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new CreateProjectCommandResponse
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var project = _mapper.Map<Project>(request);

            project.Id = Guid.NewGuid();
            project.CreatedBy = currentUserId;
            var result= await _projectRepository.AddAsync(project);

            return new CreateProjectCommandResponse
            {
                Success = true,
                Message = "Project successfully added.",
                Data = result.Id
            };
        }
    }
}
