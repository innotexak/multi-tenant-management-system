using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Contrast.Response.Project;
using TenantPM.Domain.Enums;

namespace TenantPM.Contrast.Response.TaskItem
{
    public class ContractTaskItemListVn
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public ContrastProject Project { get; set; } = null!;
        public Guid? AssignedTo { get; set; }
        public TaskItemStatus Status { get; set; }
    }
}
