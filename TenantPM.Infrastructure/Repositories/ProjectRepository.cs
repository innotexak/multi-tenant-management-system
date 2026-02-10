using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

    }

 
}
