using TenantPM.Domain.Common;
using TenantPM.Domain.Entities;
using TenantPM.Domain.Enums;

namespace TenantPM.Application.projects.Queries.TastItemList
{
    public class TaskItemListVn: BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public Guid? AssignedTo { get; set; }
        public TaskItemStatus Status { get; set; } 
    }
}