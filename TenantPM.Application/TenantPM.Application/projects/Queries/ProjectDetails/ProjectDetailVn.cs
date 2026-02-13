using TenantPM.Domain.Common;

namespace TenantPM.Application.projects.Queries.GetProject
{
    public class ProjectDetailVn: BaseResponse<ProjectDetails>
    {

    }

    public class ProjectDetails: BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}