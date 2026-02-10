using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Domain.Common;
using TenantPM.Domain.Enums;



namespace TenantPM.Domain.Entities
{
    public class TaskItem: BaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public Guid? AssignedTo { get; set; }
        public TaskItemStatus Status { get; set; } = TaskItemStatus.ToDo;
    }
}
