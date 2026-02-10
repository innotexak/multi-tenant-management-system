using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, BaseResponse<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Project> _projectRepository;

        public DeleteProjectCommandHandler(IMapper mapper, IAsyncRepository<Project> projectRepository)
        {
            _mapper=mapper;
            _projectRepository=projectRepository;
        }
        public async Task<BaseResponse<Guid>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
            {
                return new BaseResponse<Guid>
                {
                    Message = "Project not found",
                    Success = false
                };

            }

            await _projectRepository.RemoveAsync(project);

            return new BaseResponse<Guid>
            {
                Message = "Project deleted successfully",
                Success = true,
                Data = project.Id
            };

        }
    }
}
