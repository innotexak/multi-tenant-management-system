using AutoMapper;
using MediatR;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Queries.GetProject
{
    public class ProjectDetailQueryHandler : IRequestHandler<ProjectDetailQuery,  ProjectDetailVn>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Project> _projectRepository;

        public ProjectDetailQueryHandler(
            IMapper mapper, 
            IAsyncRepository<Project> projectRepository
            )
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDetailVn> Handle(
            ProjectDetailQuery request, 
            CancellationToken cancellationToken
            )
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            return new ProjectDetailVn
            {
                Message = "Details retrieved successfully",
                Success = true,
                Data = _mapper.Map<ProjectDetails>(project)
            };
        }
    }
}