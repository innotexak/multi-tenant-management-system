using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;
using TenantPM.Domain.Enums;

namespace TenantPM.Application.projects.Command.AddMemberToProject
{
    public class CreateProjectMemberCommandResponse : BaseResponse<ProjectWithMemberRecord>
    {
        
    }

    public class ProjectWithMemberRecord: BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public Project Project { get; set; }
        public Project User { get; set; }
        public RoleEnum ProjectRole { get; set; }
    }
}

