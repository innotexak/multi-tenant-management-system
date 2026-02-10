using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenantPM.Application.projects.Queries.TastItemList
{
    public class TaskItemListQuery: IRequest<TaskItemListQueryResponse>
    {
        public Guid ProjectId { get; set; }
    }
}
