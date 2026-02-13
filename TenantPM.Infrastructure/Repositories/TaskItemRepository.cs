using Microsoft.EntityFrameworkCore;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Repositories
{
    public class TaskItemRepository : BaseRepository<TaskItem>, ITaskItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskItemRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskItem>> GetItems(Guid projectId)
        {
            return await _dbContext.TaskItems
           .Include(t => t.Project)  
           .Where(t => t.ProjectId == projectId)
           .ToListAsync();

        }

        public async Task<TaskItem> GetSingleItem(Guid projectId)
        {
            return await _dbContext.TaskItems
           .Include(t => t.Project)
           .Where(t => t.ProjectId == projectId)
           .FirstOrDefaultAsync();

        }

    }
}
