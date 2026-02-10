using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.Common.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetItems(Guid projectId);
    }
}
