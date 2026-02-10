using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.projects.Queries.TastItemList;

namespace TenantPM.Application.projects.Queries.TaskItemDetails
{
    public class TaskItemQuery: IRequest<TaskItemDetailResponse>
    {
        public Guid TaskItemId { get; set; }
    }
}
