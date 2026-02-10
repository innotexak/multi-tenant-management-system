using TenantPM.Domain.Enums;

namespace TenantPM.Application.Common.Interfaces.Authorization
{
    public interface IProjectAuthorizationService
    {
        Task<bool> IsProjectMemberAsync(Guid projectId, Guid userId);
        Task<bool> HasProjectRoleAsync(Guid projectId, Guid userId, RoleEnum requiredRole);
        Task<bool> CanViewAsync(Guid projectId, Guid userId);
        Task<bool> CanManageAsync(Guid projectId, Guid userId);
    }
}
