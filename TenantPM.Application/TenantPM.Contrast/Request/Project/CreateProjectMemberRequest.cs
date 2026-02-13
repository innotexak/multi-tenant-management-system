
using TenantPM.Contrast.Enum;

namespace TenantPM.Contrast.Request.Project
{
    public class CreateProjectMemberRequest
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectEnum ProjectRole { get; set; }
    }
}
