using Microsoft.EntityFrameworkCore;
using TenantPM.Application.Common.Interfaces.Authorization;
using TenantPM.Domain.Enums;

namespace TenantPM.Infrastructure.Authorization
{
    public class ProjectAuthorizationService : IProjectAuthorizationService
    {
        private readonly ApplicationDbContext _context;

        public ProjectAuthorizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsProjectMemberAsync(Guid projectId, Guid userId)
        {
            return await _context.ProjectMembers
                .AsNoTracking()
                .AnyAsync(pm => pm.ProjectId == projectId && pm.UserId == userId);
        }

        public async Task<bool> HasProjectRoleAsync(Guid projectId, Guid userId, RoleEnum requiredRole)
        {
            return await _context.ProjectMembers
                .AsNoTracking()
                .AnyAsync(pm => pm.ProjectId == projectId &&
                                pm.UserId == userId &&
                                pm.ProjectRole == requiredRole);
        }

        public async Task<bool> CanViewAsync(Guid projectId, Guid userId)
        {
            // All project members can view
            return await IsProjectMemberAsync(projectId, userId);
        }

        public async Task<bool> CanManageAsync(Guid projectId, Guid userId)
        {
            // Only Admins or Managers can manage
            return await HasProjectRoleAsync(projectId, userId, RoleEnum.Admin)
                   || await HasProjectRoleAsync(projectId, userId, RoleEnum.Manager);
        }
    }
}
