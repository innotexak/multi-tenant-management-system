using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenantPM.Application.projects.Command.AddMemberToProject;
using TenantPM.Application.projects.Command.CreateProjectCommand;
using TenantPM.Application.projects.Command.CreateTask;
using TenantPM.Application.projects.Command.DeleteProjectCommand;
using TenantPM.Application.projects.Queries.GetProject;
using TenantPM.Application.projects.Queries.TaskItemDetails;
using TenantPM.Application.projects.Queries.TastItemList;
using TenantPM.Domain.Common;


namespace TenantPM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = "Amin")]
        [HttpPost(Name = "AddProject")]
        public async Task<BaseResponse<Guid>> AddProject(CreateProjectCommand createProjectCommand)
        {
            return await _mediator.Send(createProjectCommand);
        }

        [Authorize()]
        [HttpGet("{projectId}", Name = "GetProjectById")]
        public async Task<ProjectDetailVn> GetProjectById(Guid projectId)
        {
            var queryCommand = new ProjectDetailQuery { ProjectId = projectId };
            return await _mediator.Send(queryCommand);

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{projectId}", Name = "DeleteProject")]
        public async Task<BaseResponse<Guid>> DeleteProject(Guid projectId)
        {
            var deleteCommand = new DeleteProjectCommand { ProjectId = projectId };
            return await _mediator.Send(deleteCommand);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("{projectId}/members", Name = "CreateProjectMember")]
        public async Task<CreateProjectMemberCommandResponse> AddMemberToProject(
            [FromBody] CreateProjectMemberCommand createProjectMemberCommand, 
            Guid projectId)
        {
            var createProjectMember = new CreateProjectMemberCommand
            {
                ProjectId = projectId,
                UserId = createProjectMemberCommand.UserId,
                ProjectRole = createProjectMemberCommand.ProjectRole
            };
            return await _mediator.Send(createProjectMember);
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("{ProjectId}/tasks", Name = "CreateTask")]
        public async Task<CreateTaskCommandResponse> CreateTask(Guid ProjectId, [FromBody] CreateTaskCommand command)
        {
            command.ProjectId = ProjectId;
            return await _mediator.Send(command);
        }

        [Authorize(Roles ="Admin,Manager")]
        [HttpGet("{taskItemId}", Name = "GetTaskItemById")]
        public async Task<TaskItemDetailResponse> GetTaskItemById(Guid taskItemId)
        {
            var queryCommand = new TaskItemQuery { TaskItemId = taskItemId };
            return await _mediator.Send(queryCommand);

        }

        [Authorize()]
        [HttpGet("{ProjectId}/tasks", Name = "TaskItemList")]
        public async Task<TaskItemListQueryResponse> TaskItemList(Guid ProjectId)
        {
            var queryCommand = new TaskItemListQuery { ProjectId = ProjectId };
            return await _mediator.Send(queryCommand);

        }

    }
}
