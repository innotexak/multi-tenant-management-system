using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.AddMemberToProject
{
    public class CreateProjectMemberCommandHandler: IRequestHandler<CreateProjectMemberCommand, CreateProjectMemberCommandResponse>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IAsyncRepository<ProjectMember> _projectMemberRepo;

        public CreateProjectMemberCommandHandler(
            IMapper mapper, 
            IAsyncRepository<Project> projectRepository, 
            IAsyncRepository<User> userRepository, 
            IAsyncRepository<ProjectMember> projectMemberRepo
            )
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _projectMemberRepo= projectMemberRepo;
        }

        public async Task<CreateProjectMemberCommandResponse> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {

            var validator = new CreateProjectMemberCommandValidator(_projectRepository, _userRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid) { 
                return new CreateProjectMemberCommandResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
            }

            var projectMember = new ProjectMember
            {
                ProjectId = request.ProjectId,
                UserId = request.UserId,
                ProjectRole = request.ProjectRole,
                Id = Guid.NewGuid()
            };

            await _projectMemberRepo.AddAsync(projectMember);

            var data = _mapper.Map<ProjectWithMemberRecord>(projectMember);

            return new CreateProjectMemberCommandResponse
            {
                Success = true,
                Message = "Project member added successfully",
                Data = data
            };

        }
    }
}
