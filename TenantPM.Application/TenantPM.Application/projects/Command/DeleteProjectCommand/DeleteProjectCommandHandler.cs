using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectCommandResponse>
    {
        private readonly IAsyncRepository<Project> _projectRepository;

        public DeleteProjectCommandHandler(IAsyncRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<DeleteProjectCommandResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);

            if (project == null)
            {
                return new DeleteProjectCommandResponse
                {
                    Message = "Project not found",
                    Success = false,
                };
            }

            await _projectRepository.RemoveAsync(project);

            return new DeleteProjectCommandResponse
            {
                Message = "Project deleted successfully",
                Success = true,
                Data = project.Id
            };
        }
    }
}
