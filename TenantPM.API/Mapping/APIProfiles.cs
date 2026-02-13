using AutoMapper;
using TenantPM.Application.Auth.Command.Login;
using TenantPM.Application.Auth.Command.Register;
using TenantPM.Application.projects.Command.AddMemberToProject;
using TenantPM.Application.projects.Command.CreateProjectCommand;
using TenantPM.Application.projects.Command.CreateTask;
using TenantPM.Application.projects.Command.DeleteProjectCommand;
using TenantPM.Application.projects.Queries.GetProject;
using TenantPM.Application.projects.Queries.TaskItemDetails;
using TenantPM.Application.projects.Queries.TastItemList;
using TenantPM.Contrast.Common;
using TenantPM.Contrast.Request.Auth;
using TenantPM.Contrast.Request.Project;
using TenantPM.Contrast.Request.TaskItem;
using TenantPM.Contrast.Response.Auth;
using TenantPM.Contrast.Response.Project;
using TenantPM.Contrast.Response.TaskItem;

namespace TenantPM.API.Mapping
{
    public class APIProfiles : Profile
    {
        public APIProfiles()
        {
            CreateMap<LoginRequest, LoginCommand>();
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginCommandResponse, LoginResponse>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.Errors, opt => opt.Condition(src => !src.Success));
            CreateMap<RegisterCommandResponse, RegisterationResponse>()
                .ForMember(dest => dest.Errors, opt => opt.Condition(src => !src.Success));

   
            CreateMap<ContrastCreateTaskItemRequest, CreateTaskCommand>();
            CreateMap<CreateTaskCommandResponse, ContrastCreateTaskItemResponse>();

   
            CreateMap<CreateProjectRequest, CreateProjectCommand>();
            CreateMap<CreateProjectCommandResponse, CreateProjectResponse>();

            CreateMap<DeleteProjectRequest, DeleteProjectRequest>();
            CreateMap<DeleteProjectCommandResponse, ContrastBaseResponse<Guid>>();

            CreateMap<CreateProjectMemberRequest, CreateProjectMemberCommand>();
            CreateMap<CreateProjectMemberCommandResponse, CreateProjectMemberResponse>();

            CreateMap<ContrastCreateTaskItemRequest, CreateTaskCommand>();
            CreateMap<CreateTaskCommandResponse, ContrastCreateTaskItemResponse>();

            CreateMap<TaskItemDetailResponse, ContrastTaskItemDetailsResponse>();

            CreateMap<ProjectDetailVn, ProjectDetailsResponse>();
            CreateMap<TaskItemListQueryResponse, ProjectListDetailResponse>();
        }
    }
}
