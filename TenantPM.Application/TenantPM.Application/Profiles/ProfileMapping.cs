using AutoMapper;
using TenantPM.Application.Auth.Command.Login;
using TenantPM.Application.Auth.Command.Register;
using TenantPM.Application.projects.Command.AddMemberToProject;
using TenantPM.Application.projects.Command.CreateProjectCommand;
using TenantPM.Application.projects.Command.CreateTask;
using TenantPM.Application.projects.Queries.GetProject;
using TenantPM.Application.projects.Queries.TastItemList;
using TenantPM.Application.Users.DTOs;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.Profiles
{
    public class ProfileMapping: Profile
    {
        public ProfileMapping() {
            CreateMap<Project, CreateProjectCommand>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap()
                .ForMember(dest => dest.Role,
                       opt => opt.MapFrom(src => src.Role.ToString())); 

            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<Project, ProjectDetails>().ReverseMap();
            CreateMap<ProjectMember, ProjectWithMemberRecord>().ReverseMap()
                .ForMember(dest => dest.ProjectRole,
                       opt => opt.MapFrom(src => src.ProjectRole.ToString()));
            CreateMap<TaskItem, CreateTaskCommand>().ReverseMap();

            CreateMap<TaskItem, TaskItemListVn>().ReverseMap();
        }
    }
}
