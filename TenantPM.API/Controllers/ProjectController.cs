using AutoMapper;
using Azure;
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
using TenantPM.Contrast.Enum;
using TenantPM.Contrast.Request.Project;
using TenantPM.Contrast.Request.TaskItem;
using TenantPM.Contrast.Response.Project;
using TenantPM.Contrast.Response.TaskItem;
using TenantPM.Domain.Common;


namespace TenantPM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(Name = "AddProject")]
        public async Task<CreateProjectResponse> AddProject([FromBody] CreateProjectRequest request)
        {
   
            var command = _mapper.Map<CreateProjectCommand>(request);
            var createProjCommandResponse = await _mediator.Send(command);
            return _mapper.Map<CreateProjectResponse>(createProjCommandResponse);
        }




        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("{projectId}/members", Name = "CreateProjectMember")]
        public async Task<CreateProjectMemberResponse> AddMemberToProject(
        [FromBody] CreateProjectMemberRequest request,
        Guid projectId)
        {

            var command = _mapper.Map<CreateProjectMemberCommand>(request);
            command.ProjectId = projectId;

            var response = await _mediator.Send(command);

            return _mapper.Map<CreateProjectMemberResponse>(response);
        }


        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("{projectId}/tasks", Name = "CreateTask")]
        public async Task<ContrastCreateTaskItemResponse> CreateTask(
          Guid projectId,
          [FromBody] ContrastCreateTaskItemRequest request)
                {

            var command = _mapper.Map<CreateTaskCommand>(request);
            command.ProjectId = projectId;
            command.Status = Domain.Enums.TaskItemStatus.ToDo;

            var response = await _mediator.Send(command);

            return _mapper.Map<ContrastCreateTaskItemResponse>(response);
        }



        [Authorize()]
        [HttpGet("{projectId}", Name = "GetProjectById")]
        public async Task<ProjectDetailsResponse> GetProjectById(Guid projectId)
        {
            var queryCommand = new ProjectDetailQuery { ProjectId = projectId };
            var response = await _mediator.Send(queryCommand);

            //this 
            var l = _mapper.Map<ProjectDetailsResponse>(response);

            return l;

            //or tis
            //var projectInfo = new ProjectInfo
            //{
            //    CreatedAt = response.Data.CreatedAt,
            //    UpdatedAt = response.Data.UpdatedAt,
            //    Description = response.Data.Description,
            //    Id = response.Data.Id

            //};
            //return new ProjectDetailsResponse
            //{
            //    Success = response.Success,
            //    Message = response.Message,
            //    Data = projectInfo,
            //    Errors = !response.Success ? response.Errors:null,
            //};

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{projectId}", Name = "DeleteProject")]
        public async Task<ContrastBaseResponse<Guid>> DeleteProject(Guid projectId)
        {
            var deleteCommand = new DeleteProjectCommand { ProjectId = projectId };
            
            var deleteCommandResponse = await _mediator.Send(deleteCommand);
            return _mapper.Map<ContrastBaseResponse<Guid>>(deleteCommandResponse);
        }

    

    
        [Authorize(Roles ="Admin,Manager")]
        [HttpGet("task/{taskItemId}", Name = "GetTaskItemById")]
        public async Task<ContrastTaskItemDetailsResponse> GetTaskItemById(Guid taskItemId)
        {
            var queryCommand = new TaskItemQuery { TaskItemId = taskItemId };
            var response = _mediator.Send(queryCommand);
            return _mapper.Map<ContrastTaskItemDetailsResponse>(response);

        }

        [Authorize()]
        [HttpGet("{projectId}/tasks", Name = "TaskItemList")]
        public async Task<ProjectListDetailResponse> TaskItemList(Guid projectId)
        {
        
            var queryCommand = new TaskItemListQuery { ProjectId = projectId };
            var response = await _mediator.Send(queryCommand);
            return _mapper.Map<ProjectListDetailResponse>(response);
            

        }

    }
}
