using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.Projects.Command;
using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.CreateProjectCommand
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseResponse<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Project> _projectRepository;

        public CreateProjectCommandHandler(IMapper mapper, IAsyncRepository<Project> projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        public async Task<BaseResponse<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        { 

            var validator = new CreateProjectCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return new BaseResponse<Guid>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }
            
            var project = _mapper.Map<Project>(request);

            project.Id = Guid.NewGuid();
            project.CreatedBy = Guid.NewGuid(); 
            var result= await _projectRepository.AddAsync(project);

            return new BaseResponse<Guid>
            {
                Success = true,
                Message = "Project successfully added.",
                Data = result.Id
            };
        }
    }
}
